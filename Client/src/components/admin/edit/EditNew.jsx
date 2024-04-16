import { useState, useEffect, useRef, useCallback } from "react";
import "react-quill/dist/quill.snow.css";
import Button from "@mui/material/Button";
import AddIcon from "@mui/icons-material/Add";
import "./Edit.css";
import { getItemById, editNews, uploadToCloudinary } from "../../../api/ItemApi";
import Swal from "sweetalert2";
import { btnValue, numberLength, timeout } from "../../../enum/EnumApi";
import { Box } from "@mui/material";
import { useTranslation } from "react-i18next";
import Editor from "./reactquill/Editor";

const EditNews = ({ id, setRows, setIsPopupVisible }) => {
  const initialState = {
    id: numberLength.zero,
    title: "",
    subTitle: "",
    urlSlug: "",
    shortDescription: "",
    description: "",
    imageUrl: "",
  },
    [news, setNews] = useState(initialState);
  const imageRef = useRef(null);
  const [previewUrl, setPreviewUrl] = useState(null);
  const data = require("../../../imgURL.json");
  const editImageFrame = data.editImageFrame;
  const { t: translate } = useTranslation();

  useEffect(() => {
    resetState();
    getItem()
    async function getItem() {
      const data = await getItemById(id);
      if (data === null) {
        resetState()
      } else setNews(data)
    }
  }, [id]);

  const resetState = () => {
    setNews(initialState);
    setPreviewUrl(null);
  };

  const handleClose = () => {
    setIsPopupVisible(false);
  };

  //Onclick submit button
  const handleSubmit = (e) => {
    e.preventDefault();
    let formData = new FormData(e.target);
    formData.set("Description", news.description);
    editNews(formData).then((data) => {
      if (data) {
        Swal.fire({
          title: "Save Success",
          icon: "success",
        }).then((result) => {if (result.isConfirmed) {
          setTimeout(()=>{
            window.location.reload(false);
          }, timeout.quick)
        }})
        setRows(news);
        setIsPopupVisible(false);
        resetState()
      } 
      else {
        Swal.fire({
          title: "Error Edit News",
          icon: "error",
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
          formData.append("upload_preset", process.env.REACT_APP_CLOUDINARY_PRESET);
          const url = await uploadToCloudinary(formData);
          setNews({ ...news, imageUrl: url });
          setPreviewUrl(reader.result);
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
          <i onClick={handleClose} class="fa-solid fa-xmark"></i>
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
              value={news.id}
              onChange={(e) => setNews({ ...news, id: e.target.value })}
            ></input>
            <div className="gallery">
              <label htmlFor="uploadGallery">
                <img
                  src={ previewUrl || news.imageUrl || editImageFrame}
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
                placeholder={translate("editNews.Title")}
                className="input-title"
                type="text"
                name="Title"
                title="Title"
                value={news.title || ""}
                onChange={(e) => setNews({ ...news, title: e.target.value })}
              />
            </div>
            <div className="title">
              <p className="text-title">Slug</p>
              <input
                placeholder={translate("editNews.Slug")}
                className="input-title"
                type="text"
                name="UrlSlug"
                title="UrlSlug"
                value={news.urlSlug || ""}
                onChange={(e) => setNews({ ...news, urlSlug: e.target.value })}
              />
            </div>
            <div className="desc-edit">
              <p className="text-desc">Short Description</p>
              <textarea
                placeholder={translate("editNews.ShortDescription")}
                className="input-shdes"
                type="text"
                name="ShortDescription"
                title="ShortDescription"
                value={news.shortDescription || ""}
                onChange={(e) =>
                  setNews({ ...news, shortDescription: e.target.value })
                }
              />
            </div>
            <div className="desc-edit">
              <p className="text-desc">Description</p>
              <Editor
                name="Description"
                type="text"
                value={news.description}
                onChange={(e) => setNews({ ...news, description: e.html })}
              />
            </div>
          </div>

          <div className="btn">
            <Button
              variant={btnValue.variant}
              size={btnValue.sizeM}
              color={btnValue.colorSuccess}
              endIcon={<AddIcon />}
              type={btnValue.typeSubmit}
            >
              Add
            </Button>
          </div>
        </form>
      </Box>
    </>
  );
};

export default EditNews;
