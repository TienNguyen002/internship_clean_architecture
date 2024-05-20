import { useState, useEffect, useRef, useCallback } from "react";
import Button from "@mui/material/Button";
import AddIcon from "@mui/icons-material/Add";
import "./Edit.css";
import {
  getItemById,
  editBanner,
  uploadToCloudinary,
} from "../../../api/ItemApi";
import Swal from "sweetalert2";
import { btnValue, numberLength, saveSuccess, errorEdit, inputLength } from "../../../enum/EnumApi";
import { Box } from "@mui/material";
import { useTranslation } from "react-i18next";
import { toast } from "react-hot-toast";

const EditBanner = ({ id, setRows, setIsPopupVisible }) => {
  const initialState = {
      id: numberLength.zero,
      isDisplayed: "",
      boldTitle: "",
      japaneseBoldTitle: "",
      title: "",
      japaneseTitle: "",
      urlSlug: "",
      description: "",
      japaneseDescription: "",
      imageUrl: "",
      Locale: "",
    },
    [banner, setBanner] = useState(initialState);
  const imageRef = useRef(null);
  const [previewUrl, setPreviewUrl] = useState(null);
  const data = require("../../../imgURL.json");
  const editImageFrame = data.editImageFrame;
  const { t: translate } = useTranslation();

  useEffect(() => {
    if (id === 0) {
      resetState();
    } else if (id > 0) {
      getItem();
      async function getItem() {
        const data = await getItemById(id);
        if (data === null) {
          resetState();
        } else setBanner(data);
      }
    }
  }, [id, setIsPopupVisible]);

  const resetState = () => {
    setBanner(initialState);
    setPreviewUrl(null);
  };

  const handleClose = () => {
    setIsPopupVisible(false);
  };

  const validateInputs = () => {
    const validations = [
      { field: banner.boldTitle || '', maxLength: inputLength.maxLength100.limit, errorMessage: inputLength.maxLength100.boldTitle },
      { field: banner.japaneseBoldTitle || '', maxLength: inputLength.maxLength100.limit, errorMessage: inputLength.maxLength100.boldTitle },
      { field: banner.title || '', maxLength: inputLength.maxLength100.limit, errorMessage: inputLength.maxLength100.title },
      { field: banner.japaneseTitle || '', maxLength: inputLength.maxLength100.limit, errorMessage: inputLength.maxLength100.title },
      { field: banner.description || '', maxLength: inputLength.maxLength500.limit, errorMessage: inputLength.maxLength500.description },
      { field: banner.japaneseDescription || '', maxLength: inputLength.maxLength500.limit, errorMessage: inputLength.maxLength500.description },
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
    editBanner(formData).then((data) => {
      if (data) {
        Swal.fire({
          title: saveSuccess.title,
          icon: saveSuccess.icon,
        });
        setRows(banner);
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
          setBanner({ ...banner, imageUrl: url });
        }
      };
      reader.readAsDataURL(file);
    },
    [initialState]
  );

  return (
    <>
      <Box sx={{ padding: 5 }}>
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
              value={banner.id}
              onChange={(e) => setBanner({ ...banner, id: e.target.value })}
            ></input>
            <input
              hidden
              name="isDisplayed"
              title="isDisplayed"
              value={banner.isDisplayed}
              onChange={(e) => setBanner({ ...banner, isDisplayed: e.target.value })}
            ></input>
            <div className="gallery">
              <label htmlFor="uploadGallery">
                <img
                  src={previewUrl || banner.imageUrl || editImageFrame}
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
              </label>
            </div>
            <div className="bold-title">
              <p className="text-desc">Bold Title</p>
              <input
                placeholder={translate("editAdmin.BoldTitle")}
                className="input-title"
                type="text"
                name="BoldTitle"
                title="BoldTitle"
                value={banner.boldTitle || ""}
                onChange={(e) => setBanner({ ...banner, boldTitle: e.target.value })}
              />
              <input
                placeholder={translate("editAdminJa.BoldTitle")}
                className="input-title"
                type="text"
                name="JapaneseBoldTitle"
                title="JapaneseBoldTitle"
                value={banner.japaneseBoldTitle || ""}
                onChange={(e) => setBanner({ ...banner, japaneseBoldTitle: e.target.value })}
              />
            </div>
            <div className="title">
              <p className="text-desc">Title</p>
              <input
                placeholder={translate("editAdmin.Title")}
                className="input-title"
                type="text"
                name="Title"
                title="Title"
                value={banner.title || ""}
                onChange={(e) => setBanner({ ...banner, title: e.target.value })}
              />
              <input
                placeholder={translate("editAdminJa.Title")}
                className="input-title"
                type="text"
                name="JapaneseTitle"
                title="JapaneseTitle "
                value={banner.japaneseTitle || ""}
                onChange={(e) => setBanner({ ...banner, japaneseTitle: e.target.value })}
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
                value={banner.description || ""}
                onChange={(e) => setBanner({ ...banner, description: e.target.value })}
              />
              <textarea
                placeholder={translate("editAdminJa.Description")}
                className="input-shdes"
                type="text"
                name="JapaneseDescription"
                title="JapaneseDescription"
                value={banner.japaneseDescription || ""}
                onChange={(e) => setBanner({ ...banner, japaneseDescription: e.target.value })}
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

export default EditBanner;