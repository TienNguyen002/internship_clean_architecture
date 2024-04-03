import React, { useState, useEffect } from "react";
import "./AboutUs.css";

import { useTranslation } from "react-i18next";

const AboutUs = () => {
  const data = require("../../imgURL.json");
  const { t: translate } = useTranslation();
  const aboutUsBanner = data.aboutUsBanner;

  return (
    <div className="App">
      <div className="about-page-banner">
        <h1 className="about-page-title">{translate("titleName.About")}</h1>
        <img className="about-page-image" src={aboutUsBanner} alt=""></img>
      </div>
        <div className="about-page-container">
      <div className="about-page-content">
        <h1>{translate("about.Title")}</h1>
        <p>{translate("about.Intro1")}</p> 
        <p>{translate("about.Intro2")}</p> 
        <p>{translate("about.Intro3")}</p> 
        <p>{translate("about.Intro4")}</p> 
        </div>
      </div>
    </div>
  );
};

export default AboutUs;
