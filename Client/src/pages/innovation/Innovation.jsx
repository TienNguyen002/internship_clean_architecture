import React from 'react'
import './Innovation.css'

import { useTranslation } from 'react-i18next';

const Innovation = () => {
    const data = require("../../imgURL.json");
    const { t: translate }  = useTranslation();
    const innovationsBanner = data.innovationsBanner;
  return (
    <div className="innovation-page-banner">
    <h1 class="innovation-page-title">{translate('titleName.Innovation')}</h1>
    <img className="innovation-page-image" src={innovationsBanner} alt="Innovation AltImage"></img>
  </div>
  )
}

export default Innovation