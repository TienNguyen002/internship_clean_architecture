import React from "react";
import "./Privacy.css";

import { useTranslation } from "react-i18next";

const Privacy = () => {
  const data = require("../../imgURL.json");
  const { t: translate } = useTranslation();
  const privacyBanner = data.privacyBanner;

  return (
    <div className="App">
      <div className="privacy-page-banner">
        <h1 className="privacy-page-title">{translate("titleName.Privacy")}</h1>
        <img className="privacy-page-image" src={privacyBanner} alt="Privacy AltImage"></img>
      </div>
      <div className="privacy-page-container">
        <div className="box-body-privacy">
            <div className="privacy-page-content">
                <h1>{translate("privacy.Term")}</h1>
                <p>{translate("privacy.TermDescription")}</p>
                <h1>{translate("privacy.Security")}</h1>
                <p>{translate("privacy.SecurityDescription")}</p>
                <p>
                    <ul>
                    <li>{translate("privacy.SecurityLi1")}</li>
                    <li>{translate("privacy.SecurityLi2")}</li>
                    <li>{translate("privacy.SecurityLi3")}</li>
                    <li>{translate("privacy.SecurityLi4")}</li>
                    <li>{translate("privacy.SecurityLi5")}</li>
                    </ul>
                </p>
                <h1>{translate("privacy.Policy")}</h1>
                <p>{translate("privacy.PolicyDescription1")}</p>
                <p>{translate("privacy.PolicyDescription2")}</p>
                <h1>{translate("privacy.Change")}</h1>
                <p>{translate("privacy.ChangeDescription")}
              </p>
            </div>
        </div>
      </div>
    </div>
  );
};

export default Privacy;
