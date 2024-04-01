import { useState, useEffect, useRef, useCallback } from "react";
import ReactQuill, { Quill } from "react-quill";
import "react-quill/dist/quill.snow.css";
import ImageResize from "quill-image-resize-module-react";
import Button from "@mui/material/Button";
import AddIcon from "@mui/icons-material/Add";
import CancleIcon from "@mui/icons-material/Cancel";
import "./Edit.css";
import { editNews, getItemById } from "../../../api/ItemApi";
import Swal from "sweetalert2";
import { useNavigate, useParams } from "react-router-dom";
import { btnValue, editFormats, editModules, numberLength } from "../../../enum/EnumApi";

Quill.register("modules/imageResize", ImageResize);

const Edit = () => {
  const initialState = {
      id: numberLength.zero,
      title: "",
      description: "",
      imageUrl: ""
    },
    [news, setNews] = useState(initialState);
  const [editHtml, setEditHtml] = useState("");
  const imageRef = useRef(null);
  const [previewUrl, setPreviewUrl] = useState(null);
  const navigate = useNavigate();
  let { id }  = useParams();

  const data = require("../../../imgURL.json");
  const editImageFrame = data.editImageFrame;

  useEffect(() => {
    document.title = "Edit News";
    getItem();
    async function getItem() {
      const data = await getItemById(id);
      console.log(data)
      if (data) {
        setNews(data);
      } else setNews([]);
    }
  }, [id]);

  const handleChange = (html) => {
    setEditHtml(html);
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    let formData = new FormData(e.target);
    formData.set("Description", editHtml || news.description);
    editNews(formData).then((data) => {
      if (data) {
        Swal.fire({
          title: "Save Success",
          icon: "success",
        });
        navigate(`/admin/news`);
      } else {
        Swal.fire({
          title: "Error",
          icon: "error",
        });
      }
    });
  };


  const handleImageChange = (event) => {
    const file = event.target.files[0];
    const reader = new FileReader();
    reader.onloadend = () => {
      if (reader.result) {
        const filename = reader.result;
        setNews({ ...news, imageUrl: filename });
        setPreviewUrl(reader.result);
      }
    };
    reader.readAsDataURL(file);
  };


  const handleImage = useCallback(() => {
    const input = document.createElement("input");
    input.setAttribute("type", "file");
    input.setAttribute("accept", "image/*");
    input.click();
    input.onchange = async () => {
      if (input !== null && input.files !== null) {
        const file = input.files[0];
        const reader = new FileReader();
        reader.onload = () => {
          const fileAsDataURL = reader.result;
          if (fileAsDataURL) {
            const range = this.quill.getSelection();
            if (range !== null) {
              this.quill.insertEmbed(range.index, "image", fileAsDataURL);
            }
          }
        };
        reader.readAsDataURL(file);
      }
    };
  }, []);

  return (
    <form method="post" encType="multipart/form-data" onSubmit={handleSubmit}>
      <div className="edit-form">
        <input
          hidden
          name="Id"
          title="Id"
          value={news.id}
          onChange={(e) => e.target.value}
        ></input>
        <div className="gallery">
          <label htmlFor="uploadGallery">
            <img
              src={previewUrl || news.imageUrl || editImageFrame}
              className="img-glalery z-20"
            />
            <input
              id="uploadGallery"
              type="file"
              name="ImageFile"
              title="ImageFile"
              ref={imageRef}
              // onChange={(e) => setNews({ ...news, imageUrl: e.target.value })}
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
            placeholder="Typing your title here"
            className="input-title"
            type="text"
            name="Title"
            title="Title"
            value={news.title || ""}
            onChange={(e) => setNews({ ...news, title: e.target.value })}
          />
        </div>
        <div className="desc-edit">
          <p className="text-desc">Description</p>
          <ReactQuill
            name="Description"
            type="text"
            onChange={handleChange}
            value={editHtml || news.description}
            modules={Edit.modules}
            formats={Edit.formats}
            bounds={"#root"}
          />
        </div>
        <div className="btn">
          <Button variant={btnValue.variant} size={btnValue.sizeM} color={btnValue.colorErr} endIcon={<CancleIcon/>}>Cancle</Button>
          <Button variant={btnValue.variant} size={btnValue.sizeM} color={btnValue.colorSuccess} endIcon={<AddIcon/>} type={btnValue.typeSubmit}>Add</Button>
        </div>
      </div>
    </form>
  );
};

Edit.modules = editModules

Edit.formats = editFormats

export default Edit;
