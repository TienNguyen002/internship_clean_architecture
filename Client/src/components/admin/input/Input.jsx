import React from "react";
import "./Input.css";
export const InputBox = ({
  name,
  type,
  id,
  value,
  placeholer,
  icon,
  disable = false,
}) => {
  return (
    <div className="input-cms">
      <input
        name={name}
        type={type}
        placeholder={placeholer}
        defaultValue={value}
        id={id}
        disabled={disable}
        className={name === "title" || "japaneseTitle" ? "input-box-title" : `input-box`}
      />
      <i className={"fa-" + icon + " input-icon"}></i>
    </div>
  );
};

export const BoxHolder = ({
  name,
  type,
  id,
  value,
  placeholer,
  icon,
  disable = false,
}) => {
  return (
    <div className="input-cms">
      <input
        name={name}
        type={type}
        placeholder={placeholer}
        value={value}
        id={id}
        disabled={disable}
        className={name === "title" || "japaneseTitle" ? "input-box-title" : `input-box`}
      />
      <i className={"fa-" + icon + " input-icon"}></i>
    </div>
  );
};

