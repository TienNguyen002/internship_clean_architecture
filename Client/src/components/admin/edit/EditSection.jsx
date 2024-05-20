import { useState, useEffect, useRef, useCallback } from "react";
import Button from "@mui/material/Button";
import AddIcon from "@mui/icons-material/Add";
import "./Edit.css";
import {
  getSectionById,
  editSection,
  uploadToCloudinary,
  uploadImageEditor,
} from "../../../api/ItemApi";
import Swal from "sweetalert2";
import { btnValue, numberLength, allowedExtensions, saveSuccess, errorEdit, allowedSectionsName, inputLength } from "../../../enum/EnumApi";
import { Box } from "@mui/material";
import { useTranslation } from "react-i18next";
import dataText from "../../../locales/en/translation.json";
import { toast, Toaster } from "react-hot-toast";

const EditSection = ({ id, setRows, setIsPopupVisible, currentLanguage }) => {
  const initialState = {
      id: numberLength.zero,
      name: "",
      title: "",
      japaneseTitle: "",
      urlSlug: "",
      description: "",
      japaneseDescription: "",
      imageUrl: "",
      Locale: "",
    },
    [section, setSection] = useState(initialState);
  const text = dataText;
  const imageRef = useRef(null);
  const [previewUrl, setPreviewUrl] = useState(null);
  const data = require("../../../imgURL.json");
  const editImageFrame = data.editImageFrame;
  const { t: translate } = useTranslation();

  useEffect(() => {
    if (id > 0) {
        resetState();
        getItem();
    }
    else {
        resetState();
    }
    async function getItem() {
      const data = await getSectionById(id);
      if (data === null) {
        resetState();
      } else setSection(data);
    }
  }, [id, setIsPopupVisible]);

  const resetState = () => {
    setPreviewUrl(section.backgroundUrl || null);
    setSection(initialState);
  };

  const handleClose = () => {
    setIsPopupVisible(false);
    id = 0;
  };

  const validateInputs = () => {
    const validations = [
      { field: section.name || '', maxLength: inputLength.maxLength100.limit, errorMessage: inputLength.maxLength100.name },
      { field: section.urlSlug || '', maxLength: inputLength.maxLength100.limit, errorMessage: inputLength.maxLength100.slug },
      { field: section.title || '', maxLength: inputLength.maxLength100.limit, errorMessage: inputLength.maxLength100.title },
      { field: section.japaneseTitle || '', maxLength: inputLength.maxLength100.limit, errorMessage: inputLength.maxLength100.title },
      { field: section.description || '', maxLength: inputLength.maxLength500.limit, errorMessage: inputLength.maxLength500.description },
      { field: section.japaneseDescription || '', maxLength: inputLength.maxLength500.limit, errorMessage: inputLength.maxLength500.description },
    ];

    for (let i = 0; i < validations.length; i++) {
      const { field, maxLength, errorMessage } = validations[i];
      if (field && field.length > maxLength) {
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
    editSection(formData).then((data) => {
      if (data) {
        Swal.fire({
          title: saveSuccess.title,
          icon: saveSuccess.icon,
        });
        setRows(section);
        setIsPopupVisible(false);
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
          const filename = reader.result;
          const formData = new FormData();
          formData.append("file", filename);
          formData.append(
            "upload_preset",
            process.env.REACT_APP_CLOUDINARY_PRESET
          );
          const url = await uploadToCloudinary(formData);
          setSection({ ...section, imageUrl: url });
          setPreviewUrl(reader.result);
        }
      };
      reader.readAsDataURL(file);
    },
    [initialState]
  );

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
      if (!imageFile.name.match(new RegExp(`\.(${allowedExtensions.join('|')})$$`))) {
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
              value={section.id}
              onChange={(e) => setSection({ ...section, id: e.target.value })}
            ></input>
            <input
              hidden
              name="Locale"
              title="Locale"
              value={currentLanguage}
              onChange={(e) => setSection({ ...section, Locale: e.target.value })}
            ></input>
            <div className="gallery">
              <label htmlFor="uploadGallery">
               {section?.name && allowedSectionsName.includes(section.name) ? (
                  <>
                    <img
                      src={previewUrl || section.backgroundUrl || editImageFrame}
                      className="img-glalery z-20"
                    />
                    <input
                      id="uploadGallery"
                      type="file"
                      name="BackgroundImage"
                      title="BackgroundImage"
                      ref={imageRef}
                      onChange={handleImageChange}
                      accept=".png, .jpg, .jpeg"
                      className="setGallery"
                      hidden
                    />
                  </>
                ) : null}
              </label>
            </div>
            <div className="bold-title">
              <p className="text-title">Name</p>
              <input
                placeholder={translate("editAdmin.Name")}
                className="input-title"
                type="text"
                name="Name"
                title="Name"
                value={section.name || ""}
                onChange={(e) => setSection({ ...section, name: e.target.value })}
              />
            </div>
            <div className="title">
              <p className="text-title">Title</p>
              <input
                placeholder={translate("editAdmin.Title")}
                className="input-title"
                type="text"
                name="Title"
                title="Title"
                value={section.title || ""}
                onChange={(e) =>
                  setSection({ ...section, title: e.target.value })
                }
              />
              <input
                placeholder={translate("editAdminJa.Title")}
                className="input-title"
                type="text"
                name="JapaneseTitle"
                title="JapaneseTitle"
                value={section.japaneseTitle || ""}
                onChange={(e) =>
                  setSection({ ...section, japaneseTitle: e.target.value })
                }
              />
            </div>
            <div className="title">
              <p className="text-title">Slug</p>
              <input
                placeholder={translate("editAdmin.Slug")}
                className="input-title"
                type="text"
                name="UrlSlug"
                title="UrlSlug"
                value={section.urlSlug || ""}
                onChange={(e) =>
                  setSection({ ...section, urlSlug: e.target.value })
                }
              />
            </div>
            <div className="desc-edit">
              <p className="text-desc">Description</p>
                <textarea
                placeholder={translate("editAdmin.Description")}
                className="input-shdes"
                type="text"
                name="Description"
                title="Description"
                value={section.description || ""}
                onChange={(e) =>
                  setSection({ ...section, description: e.target.value })
                }
              />
                <textarea
                placeholder={translate("editAdminJa.Description")}
                className="input-shdes"
                type="text"
                name="JapaneseDescription"
                title="JapaneseDescription"
                value={section.japaneseDescription || ""}
                onChange={(e) =>
                  setSection({ ...section, japaneseDescription: e.target.value })
                }
              />
            </div>
          </div>

          <div className="btn-apply">
            <Button
              variant={btnValue.variant}
              size={btnValue.sizeM}
              color={btnValue.colorSuccess}
              endIcon={<AddIcon />}
              type={btnValue.typeSubmit}
            >
              {text.adminPage.Save}
            </Button>
          </div>
        </form>
      </Box>
    </>
  );
};

export default EditSection;