import { useState, useEffect, useRef, useCallback } from "react";
import Button from "@mui/material/Button";
import AddIcon from "@mui/icons-material/Add";
import "./Edit.css";
import {
  getItemById,
  editBlog,
  uploadToCloudinary,
  uploadImageEditor,
} from "../../../api/ItemApi";
import Swal from "sweetalert2";
import { btnValue, language, numberLength, saveSuccess, errorEdit, inputLength } from "../../../enum/EnumApi";
import { Box } from "@mui/material";
import { useTranslation } from "react-i18next";
import JoditReact from "jodit-react";
import { toast, Toaster } from "react-hot-toast";

const EditBlog = ({ id, setRows, setIsPopupVisible }) => {
  const initialState = {
    id: numberLength.zero,
    title: "",
    japaneseTitle: "",
    subTitle: "",
    shortDescription: "",
    japaneseShortDescription: "",
    description: "",
    japaneseDescription: "",
    imageUrl: "",
  },
    [blog, setBlog] = useState(initialState);
  const imageRef = useRef(null);
  const [previewUrl, setPreviewUrl] = useState(null);
  const data = require("../../../imgURL.json");
  const editImageFrame = data.editImageFrame;
  const { t: translate } = useTranslation();

  const editor = useRef("");
  const editorja = useRef("");

  useEffect(() => {
    if (id === 0) {
      resetState();
    }
    if (id > 0) {
      resetState();
      getItem();
      async function getItem() {
        const data = await getItemById(id);
        if (data === null) {
          resetState();
        } else setBlog(data);
      }
    }
  }, [id, setIsPopupVisible]);

  const resetState = () => {
    editorja.current.value="";
    editor.current.value="";
    setBlog(initialState);
    setPreviewUrl(null);
  };

  const handleClose = () => {
    setIsPopupVisible(false);
  };

  const validateInputs = () => {
    const validations = [
      { field: blog.title, maxLength: inputLength.maxLength100.limit, errorMessage: inputLength.maxLength100.title },
      { field: blog.japaneseTitle, maxLength: inputLength.maxLength100.limit, errorMessage: inputLength.maxLength100.title },
      { field: blog.subTitle, maxLength: inputLength.maxLength100.limit, errorMessage: inputLength.maxLength100.author },
      { field: blog.shortDescription, maxLength: inputLength.maxLength500.limit, errorMessage: inputLength.maxLength500.shortDescription },
      { field: blog.japaneseShortDescription, maxLength: inputLength.maxLength500.limit, errorMessage: inputLength.maxLength500.shortDescription },
    ];

    for (let i = 0; i < validations.length; i++) {
      const { field, maxLength, errorMessage } = validations[i];
      if (field.length > maxLength) {
        toast.error(errorMessage);
        return false;
      }
    }
    return true;
  };

  //Onclick submit button
  const handleSubmit = (e) => {
    e.preventDefault();

    if (!validateInputs()) {
      return;
    }

    let formData = new FormData(e.target);
    formData.set("Description", editor.current.value || blog.description);
    formData.set("JapaneseDescription", editorja.current.value || blog.japaneseDescription);
    editBlog(formData).then((data) => {
      if (data) {
        Swal.fire({
          title: saveSuccess.title,
          icon: saveSuccess.icon,
        });
        setRows(blog);
        setIsPopupVisible(false);
        resetState();
      } else {
        Swal.fire({
          title: errorEdit.title,
          icon: errorEdit.icon,
        });
      }
    });
  };

  const handleImageChange = useCallback(
    (e) => {
      const file = e.target.files[0];
      const reader = new FileReader();
      reader.onloadend = async () => {
        if (reader.result) {
          setPreviewUrl(reader.result);
          const filename = reader.result;
          const formData = new FormData();
          formData.append("file", filename);
          formData.append(
            "upload_preset",
            process.env.REACT_APP_CLOUDINARY_PRESET
          );
          const url = await uploadToCloudinary(formData);
          setBlog({ ...blog, imageUrl: url });
        }
      };
      reader.readAsDataURL(file);
    },
    [initialState]
  );

  const editorConfig = {
    readonly: false,
    toolbar: true,
    spellcheck: false,
    language: language.english,
    toolbarButtonSize: btnValue.sizeM,
    toolbarAdaptive: false,
    showCharsCounter: false,
    showWordsCounter: false,
    showXPathInStatusbar: false,
    askBeforePasteHTML: true,
    askBeforePasteFromWord: true,
    width: 800,
    height: 500,
    defaultActionOnPaste: "insert_clear_html",
    placeholder: "Write something awesome...",
    beautyHTML: true,
    controls: {
      image: {
        exec: async (editor) => {
          await imageUpload(editor);
        },
      },
    },
  };
  const imageUpload = async (editor) => {
    const input = document.createElement("input");
    input.setAttribute("type", "file");
    input.setAttribute("accept", "image/*");
    input.click();

    input.onchange = async function () {
      const imageFile = input.files[0];

      if (!imageFile) {
        return;
      }

      if (!imageFile.name.match(/\.(jpg|jpeg|png)$/)) {
        return;
      }

      const imageInfo = await uploadImageEditor(imageFile);

      insertImage(editor, imageInfo);
    };
  };

  const insertImage = (editor, image) => {
    const imgNode = editor.create.fromHTML(
      `<img src="${image.secure_url}" alt="${image.original_filename}" />`
    );
    editor.selection.insertNode(imgNode);
  };

  return (
    <>
      <Box sx={{ padding: 5 }}>
      <Toaster
          containerStyle={{
            top: 100,
          }}
        />
      <div className="btn-cancel">
          <i onClick={handleClose} className="fa-solid fa-xmark"></i>
        </div>
        <form
          method="post"
          encType="multipart/form-data"
          onSubmit={handleSubmit}
        >
          <div className="edit-form">
            <input
              hidden
              name="Id"
              title="Id"
              value={blog.id}
              onChange={(e) => setBlog({ ...blog, id: e.target.value })}
            ></input>
            <div className="gallery">
              <label htmlFor="uploadGallery">
                <img
                  src={previewUrl || blog.imageUrl || editImageFrame}
                  className="img-glalery z-20"
                />
                <input
                  id="uploadGallery"
                  type="file"
                  name="ImageFile"
                  title="ImageFile"
                  ref={imageRef}
                  onChange={handleImageChange}
                  accept=".png, .jpg, .jpeg"
                  className="setGallery"
                  hidden
                />
              </label>
            </div>
              <div className="title">
                <p className="text-title">Title</p>
                <input
                  placeholder={translate("editAdmin.Title")}
                  className="input-title"
                  type="text"
                  name="Title"
                  title="Title"
                  value={blog.title || ""}
                  onChange={(e) => setBlog({ ...blog, title: e.target.value })}
                />
              </div>
              <div className="title">
                <input
                  placeholder={translate("editAdminJa.Title")}
                  className="input-title"
                  type="text"
                  name="JapaneseTitle"
                  title="JapaneseTitle"
                  value={blog.japaneseTitle || ""}
                  onChange={(e) => setBlog({ ...blog, japaneseTitle: e.target.value })}
                />
              </div>
            <div className="short-title">
              <p className="text-title">Author</p>
              <input
                placeholder={translate("editAdmin.Author")}
                className="input-title"
                type="text"
                name="SubTitle"
                title="SubTitle"
                value={blog.subTitle || ""}
                onChange={(e) => setBlog({ ...blog, subTitle: e.target.value })}
              />
            </div>
              <div className="desc-edit">
                <p className="text-desc">Short Description</p>
                <textarea
                  placeholder={translate("editAdmin.ShortDescription")}
                  className="input-shdes"
                  type="text"
                  name="ShortDescription"
                  title="ShortDescription"
                  value={blog.shortDescription || ""}
                  onChange={(e) =>
                    setBlog({ ...blog, shortDescription: e.target.value })
                  }
                />
              </div>
              <div className="desc-edit">
                <textarea
                  placeholder={translate("editAdminJa.ShortDescription")}
                  className="input-shdes"
                  type="text"
                  name="JapaneseShortDescription"
                  title="JapaneseShortDescription"
                  value={blog.japaneseShortDescription || ""}
                  onChange={(e) =>
                    setBlog({ ...blog, japaneseShortDescription: e.target.value })
                  }
                />
              </div>
                <div className="desc-edit">
                  <p className="text-desc">Description</p>
                  <JoditReact
                    ref={editor}
                    name="Description"
                    type="text"
                    value={blog.description}
                    config={editorConfig}
                  />
                </div>
                  <JoditReact
                    ref={editorja}
                    name="JapaneseDescription"
                    type="text"
                    value={blog.japaneseDescription}
                    config={editorConfig}
                  />
          </div>

          <div className="btn-apply">
            <Button
              variant={btnValue.variant}
              size={btnValue.sizeM}
              color={btnValue.colorSuccess}
              endIcon={<AddIcon />}
              type={btnValue.typeSubmit}
            >
              {id === 0 ? "Add" : "Save"}
            </Button>
          </div>
        </form>
      </Box>
    </>
  );
};

export default EditBlog;
