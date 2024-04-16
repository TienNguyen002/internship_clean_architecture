import React from "react";
import "./Domain.css";

import { useTranslation } from 'react-i18next';

const Domain = () => {
  const { t: translate } = useTranslation();
  const data = require("../../imgURL.json");
  const servicesBanner = data.servicesBanner;

  return (
    <div className="domain-page-banner">
      <h1 class="domain-page-title">{translate('titleName.Domain')}</h1>
      <img className="domain-page-image" src={servicesBanner} alt="Domain AltImage"></img>
    </div>
  )
}

export default Domain;