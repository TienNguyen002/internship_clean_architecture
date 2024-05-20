import React, { useEffect, useState } from "react";
import { useParams, useNavigate } from "react-router-dom";
import { editItems, getItemById } from "../../../api/ItemApi";
import Swal from "sweetalert2";
import SideBar from "../sideBar/SideBar";
import { Box } from "@mui/material";
import "../../../pages/admin/dashBoard/DashBoard.css";
import { SwalEnum, inputLength, slugName } from "../../../enum/EnumApi";
import { toast, Toaster } from "react-hot-toast";
import { InputBox } from "../input/Input";

const EditRequest = () => {
  const initialState = {
    id: "",
    categorySlug: slugName.request,
    title: "",
    japaneseTitle: "",
    description: "",
    japaneseDescription: "",
    buttonLabel: "",
    japaneseButtonLabel: "",
  };
  let { id } = useParams();
  const [request, setRequest] = useState(initialState);
  const navigate = useNavigate();

  useEffect(() => {
    getItemById(id).then((data) => {
      if (data) {
        setRequest(data);
      } else setRequest([]);
    });
  }, [id]);

  const handleSubmit = (e) => {
    e.preventDefault();

    let form = new FormData(e.target);
    let formData = {};
    for (let [key, value] of form.entries()) {
      formData[key] = value;
    }

    let { title, japaneseTitle, description, japaneseDescription, buttonLabel, japaneseButtonLabel } = formData;

    editItems(formData).then(() => {
      if (!title.length || title.length > inputLength.maxLength100.limit) {
        return toast.error(inputLength.maxLength100.text);
      }
      if (!japaneseTitle.length || japaneseTitle.length > inputLength.maxLength100.limit) {
        return toast.error(inputLength.maxLength100.textJa);
      }
      if (!description.length || description.length > inputLength.maxLength500.limit) {
        return toast.error(inputLength.maxLength500.text);
      }
      if (!japaneseDescription.length || japaneseDescription.length > inputLength.maxLength500.limit) {
        return toast.error(inputLength.maxLength500.textJa);
      }
      if (!buttonLabel.length) {
        return toast.error(inputLength.buttonLabel);
      }
      if (!japaneseButtonLabel.length) {
        return toast.error(inputLength.buttonLabelJa);
      }

      setRequest(request);
      Swal.fire({
        title: SwalEnum.titleSuccess,
        icon: SwalEnum.iconSuccess,
      });

      navigate("/admin");
    });
  };

  const handleBack = () => {
    navigate("/admin");
  };
  return (
    <>
      <Box sx={{ padding: 10, display: "flex" }}>
        <SideBar name={`Change "${request.title}"`} />
        <Box component="main" sx={{ flexGrow: 1 }}>
          <Toaster />
          <form
            method="post"
            encType="multipart/form-data"
            onSubmit={handleSubmit}
            className="request-edit-form"
          >
            <input
              hidden
              name="Id"
              title="Id"
              value={request.id}
              onChange={(e) => setRequest({ ...request, id: e.target.value })}
            />
            <input
              hidden
              name="CategorySlug"
              value={request.categorySlug}
              onChange={(e) => setRequest({ ...request, categorySlug: e.target.value })}
            />
            <h2>English Title</h2>
            <InputBox
              type="text"
              name="title"
              placeholer="English Title"
              value={request.title}
              onChange={(e) =>
                setRequest({ ...request, title: e.target.value })
              }
            />
            <h2>Japanese Title</h2>
            <InputBox
              type="text"
              name="japaneseTitle"
              placeholer="Japanese Title"
              value={request.japaneseTitle}
              onChange={(e) =>
                setRequest({ ...request, japaneseTitle: e.target.value })
              }
            />
            <h3>Description English</h3>
            <InputBox
              name="description"
              value={request.description}
              onChange={(e) =>
                setRequest({ ...request, description: e.target.value })
              }
            />
            <h3>Description Japanese</h3>
            <InputBox
              name="japaneseDescription"
              value={request.japaneseDescription}
              onChange={(e) =>
                setRequest({ ...request, japaneseDescription: e.target.value })
              }
            />
            <h3>Button Label English</h3>
            <InputBox
              name="buttonLabel"
              value={request.buttonLabel}
              onChange={(e) =>
                setRequest({ ...request, buttonLabel: e.target.value })
              }
            />
            <h3>Button Label Japanese</h3>
            <InputBox
              name="japaneseButtonLabel"
              value={request.japaneseButtonLabel}
              onChange={(e) =>
                setRequest({ ...request, japaneseButtonLabel: e.target.value })
              }
            />
            <div className="cms-back-update">
              <button onClick={handleBack} className="cms-back-btn">
                Cancel
              </button>
              <button type="submit" className="cms-update-btn">
                Update
              </button>
            </div>
          </form>
        </Box>
      </Box>
    </>
  );
};

export default EditRequest;
