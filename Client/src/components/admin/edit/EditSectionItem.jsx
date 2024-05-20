import { useState, useEffect, useRef, useCallback } from "react";
import Button from "@mui/material/Button";
import AddIcon from "@mui/icons-material/Add";
import "./Edit.css";
import {
  getItemById,
  editItems,
  uploadToCloudinary,
} from "../../../api/ItemApi";
import Swal from "sweetalert2";
import { btnValue, numberLength, language, saveSuccess, inputLength, titleLinks } from "../../../enum/EnumApi";
import { Box } from "@mui/material";
import { useTranslation } from "react-i18next";
import { useLocation } from 'react-router-dom';
import JoditReact from "jodit-react";
import { toast, Toaster } from "react-hot-toast";

const EditSectionItem = ({ id, sectionSlug, setRows, setIsPopupVisible }) => {
  const initialState = {
      id: numberLength.zero,
      sectionSlug: sectionSlug,
      title: "",
      japaneseTitle: "",
      subTitle: "",
      japaneseSubTitle: "",
      description: "",
      japaneseDescription: "",
      imageUrl: "",
      hyperlink: ""
    },
    [sectionItem, setsectionItem] = useState(initialState);
  const location = useLocation();
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
      getItem();
      async function getItem() {
        const data = await getItemById(id);
        if (data === null) {
          resetState();
        } else setsectionItem(data);
      }
    }
  }, [id, setIsPopupVisible]);

  const resetState = () => {
    setsectionItem(initialState);
    setPreviewUrl(null);
  };

  const handleClose = () => {
    setIsPopupVisible(false);
  };

  //Onclick submit button
  const handleSubmit = (e) => {
    e.preventDefault();
    let form = new FormData(e.target);

    let formData = {};
    for (let [key, value] of form.entries()) {
      formData[key] = value;
    }

    let { title, japaneseTitle, subTitle, japaneseSubTitle, hyperlink } = formData;
    if (!title.length || title.length > inputLength.maxLength100.limit) {
      return toast.error(inputLength.maxLength100.text);
    }
    if (!japaneseTitle.length || japaneseTitle.length > inputLength.maxLength100.limit) {
      return toast.error(inputLength.maxLength100.textJa);
    }
    if(subTitle){
      if (!subTitle.length) {
        return toast.error(inputLength.maxLength500.text);
      }
      if (!japaneseSubTitle.length) {
        return toast.error(inputLength.maxLength500.textJa);
      }
    }
    if(hyperlink){
      if (!hyperlink.length) {
        return toast.error(inputLength.hyperLink);
      }
    }
    editItems(formData).then((data) => {

      if (data) {
        Swal.fire({
          title: saveSuccess.title,
          icon: saveSuccess.icon,
        });
        setRows(sectionItem);
        setIsPopupVisible(false);
        resetState()
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
          setsectionItem({ ...sectionItem, imageUrl: url });
          setPreviewUrl(reader.result);
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
              value={sectionItem.id}
              onChange={(e) => setsectionItem({ ...sectionItem, id: e.target.value })}
            ></input>
            <input
              hidden
              name="SectionSlug"
              title="SectionSlug"
              value={sectionSlug}
              onChange={(e) => setsectionItem({ ...sectionItem, sectionSlug: e.target.value })}
            ></input>
            <div className="gallery">
              <label htmlFor="uploadGallery">
                <img
                  src={previewUrl || sectionItem.imageUrl || editImageFrame}
                  className="img-glalery z-20"
                />
                <input
                  id="uploadGallery"
                  type="file"
                  name="imageFile"
                  title="imageFile"
                  ref={imageRef}
                  onChange={handleImageChange}
                  accept=".png, .jpg, .jpeg"
                  className="setGallery"
                  hidden
                />
              </label>
            </div>
            <div className="title">
              <p className="text-desc">Title</p>
              <input
                placeholder={translate("editAdmin.Title")}
                className="input-title"
                type="text"
                name="title"
                title="title"
                value={sectionItem.title || ""}
                onChange={(e) => setsectionItem({ ...sectionItem, title: e.target.value })}
              />
              <input
                placeholder={translate("editAdminJa.Title")}
                className="input-title"
                type="text"
                name="japaneseTitle"
                title="japaneseTitle"
                value={sectionItem.japaneseTitle || ""}
                onChange={(e) => setsectionItem({ ...sectionItem, japaneseTitle: e.target.value})
                }
              />
            </div>
            {location.pathname === titleLinks.Customers.adminLink ? (
              <div className="title">
                <p className="text-desc">Role</p>
                <input
                  placeholder={translate("editAdmin.SubTitle")}
                  className="input-title"
                  type="text"
                  name="subTitle"
                  title="subTitle"
                  value={sectionItem.subTitle || ""}
                  onChange={(e) => setsectionItem({ ...sectionItem, subTitle: e.target.value })}
                />
                <input
                  placeholder={translate("editAdminJa.SubTitle")}
                  className="input-title"
                  type="text"
                  name="japaneseSubTitle"
                  title="japaneseSubTitle"
                  value={sectionItem.japaneseSubTitle || ""}
                  onChange={(e) => setsectionItem({ ...sectionItem, japaneseSubTitle: e.target.value })}
                />
              </div>
            ) : null}
            {location.pathname === titleLinks.Clients.adminLink ||
            location.pathname === titleLinks.AsRecognizedBy.adminLink ? (
              <div className="title">
                <p className="text-desc">Hyper Link</p>
                <input
                  className="input-title"
                  type="text"
                  name="hyperlink"
                  title="hyperlink"
                  value={sectionItem.hyperlink || ""}
                  onChange={(e) => setsectionItem({ ...sectionItem, hyperlink: e.target.value })}
                />
              </div>
            ) : null}
              <div className="desc-edit">
                <p className="text-desc">Description</p>
                <JoditReact
                  ref={editor}
                  name="description"
                  type="text"
                  value={sectionItem.description}
                  config={editorConfig}
                />
                <p className="text-desc">Japanese Description</p>
                <JoditReact
                  ref={editorja}
                  name="japaneseDescription"
                  type="text"
                  value={sectionItem.japaneseDescription}
                  config={editorConfig}
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
              {id === 0 ? "Add" : "Save"}
            </Button>
          </div>
        </form>
      </Box>
    </>
  );
};

export default EditSectionItem;