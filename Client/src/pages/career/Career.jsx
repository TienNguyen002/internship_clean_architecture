import React from "react";
import "./Career.css";
import { useTranslation } from 'react-i18next';

const Career = () => {
  const data = require("../../imgURL.json");
  const bannerBG = data.bannerBG;
  const careerImg = data.careerImg;
  const { t: translate } = useTranslation();

  return (
    <>
      <div className="career-banner">
        <h1 class="career-title">{translate('career.Title')}</h1>
        <img className="career-banner-image" src={bannerBG} alt=""></img>
      </div>
        <div className="career-container">
      <div className="career-content">
          <div >
            <img className="career-image" src={careerImg} alt=""></img>
          </div>
          <div className="career-description">
            <p>
              {translate('career.Intro1')}
              <strong>{translate('career.Inspire')}</strong>{translate('career.Is')}
              <em>{translate('career.Intro2')}</em>".
            </p>
            <p>
              {translate('career.Intro3')}
            </p>
            <p>
              <strong>{translate('career.Welcome')}</strong>:
            </p>
            <ul>
              <li>{translate('career.List1')}</li>
              <li>{translate('career.List2')}</li>
              <li>{translate('career.List3')}</li>
              <li>{translate('career.List4')}</li>
              <li>{translate('career.List5')}</li>
              <li>{translate('career.List6')}</li>
            </ul>
            <p>
              <strong>
                {translate('career.Required')}
              </strong>
            </p>
            <p>
              <strong>
                {translate('career.Contact')}
              </strong>
              <a href="mailto:recruitment@titancorpvn.com">
                <strong>{translate('career.Email')}</strong>
              </a>
            </p>
          </div>
        </div>
      </div>
    </>
  );
};

export default Career;

  
