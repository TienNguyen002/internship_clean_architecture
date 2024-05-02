import React, { useEffect, useState } from "react";
import { useParams, useNavigate } from "react-router-dom";
import { getItemById, updateFooter } from "../../../api/ItemApi";
import Swal from "sweetalert2";
import InputBox from "../input/Input";
import SideBar from "../sideBar/SideBar";
import { Box } from "@mui/material";
import { splitIcon } from "../../../common/functions";
import "../../../pages/admin/dashBoard/DashBoard.css"
import { SwalEnum } from "../../../enum/EnumApi";
const AdFooter = () => {
  const initialState = {
    id: "",
    title: "",
    address: "",
    telNumber: "",
    description: "",
    infoGmail: "",
    infoGmail2: "",
    subItems: [
      {
        facebook: "",
        twitter: "",
        linkedin: "",
        youtube: "",
      },
    ],
  };
  let { id } = useParams();
  const [footer, setFooter] = useState(initialState);
  const navigate = useNavigate();

  useEffect(() => {
    getItemById(id).then((data) => {
      if (data) {
        setFooter(data);
      } else setFooter([]);
    });
  }, []);

  const handleSubmit = (e) => {
    e.preventDefault();
    let formData = new FormData(e.target);
    updateFooter(formData).then((data) => {
      if (data) {
        Swal.fire({
          title: SwalEnum.titleSuccess,
          icon: SwalEnum.iconSuccess,
        });
        setFooter(footer);
      } else {
        Swal.fire({
          title: SwalEnum.titleError,
          icon: SwalEnum.iconError,
        });
      }
      navigate("/admin");
    });
  };

  const handleBack = () => {
    navigate("/admin");
  };
  return (
    <>
      <Box sx={{ padding: 10, display: "flex" }}>
        <SideBar name={`Change ${footer.title}`} />
        <Box component="main" sx={{ flexGrow: 1 }}>
          <form
            method="post"
            encType="multipart/form-data"
            onSubmit={handleSubmit}
          >
            <input
              hidden
              name="Id"
              title="Id"
              value={footer.id}
              onChange={(e) => setFooter({ ...footer, id: e.target.value })}
            />
            <i className={"fa-solid fa-location-dot" + " input-icon"}></i>

            <InputBox
              className="input-title"
              type="text"
              name="title"
              title="Title"
              value={footer.title || ""}
              onChange={(e) => setFooter({ ...footer, title: e.target.value })}
            />
            {footer.address ? (
              <div>
                <InputBox
                  name="address"
                  title="Address"
                  icon="solid fa-location-dot"
                  value={footer.address}
                  onChange={(e) =>
                    setFooter({ ...footer, address: e.target.value })
                  }
                />
                <InputBox
                  name="telNumber"
                  icon="solid fa-phone"
                  value={footer.telNumber}
                  onChange={(e) =>
                    setFooter({ ...footer, telNumber: e.target.value })
                  }
                />
              </div>
            ) : footer.description ? (
              <InputBox
                name="description"
                value={footer.description}
                onChange={(e) =>
                  setFooter({ ...footer, description: e.target.value })
                }
              />
            ) : footer.infoGmail ? (
              <>
                <InputBox
                  name="infoGmail"
                  icon="solid fa-envelope"
                  value={footer.infoGmail}
                  onChange={(e) =>
                    setFooter({ ...footer, infoGmail: e.target.value })
                  }
                />
                <InputBox
                  name="infoGmail2"
                  icon={
                    footer.infoGmail2 === "titancorpvn"
                      ? "brands fa-skype"
                      : "solid fa-envelope"
                  }
                  value={footer.infoGmail2}
                  onChange={(e) =>
                    setFooter({ ...footer, infoGmail2: e.target.value })
                  }
                />
              </>
            ) : footer.subItems ? (
              footer.subItems.map((subItem) => (
                <>
                  <InputBox
                    name="facebook"
                    icon={`brands fa-${splitIcon(subItem.facebook)} `}
                    value={subItem.facebook}
                    onChange={(e) =>
                      setFooter({ ...footer, facebook: e.target.value })
                    }
                  />
                  <InputBox
                    name="twitter"
                    icon={`brands fa-${splitIcon(subItem.twitter)} `}
                    value={subItem.twitter}
                    onChange={(e) =>
                      setFooter({ ...footer, twitter: e.target.value })
                    }
                  />
                  <InputBox
                    name="linkedin"
                    icon={`brands fa-${splitIcon(subItem.linkedin)} `}
                    value={subItem.linkedin}
                    onChange={(e) =>
                      setFooter({ ...footer, linkedin: e.target.value })
                    }
                  />
                  <InputBox
                    name="youtube"
                    icon={`brands fa-${splitIcon(subItem.youtube)} `}
                    value={subItem.youtube}
                    onChange={(e) =>
                      setFooter({ ...footer, youtube: e.target.value })
                    }
                  />
                </>
              ))
            ) : null}
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

export default AdFooter;
