import React, { useState, useEffect } from "react";
import Box from "../../components/box/Box";
import './Service.css'

import { getAllSection } from "../../api/ItemApi";
import { useSelector } from "react-redux";
import { useTranslation } from 'react-i18next';

function Service() {
  const [box, setBox] = useState([]);
  const { t: translate }  = useTranslation();

  const data = require("../../imgURL.json");
  const servicesBanner = data.servicesBanner;

  const currentLanguage = useSelector(
    (state) => state.language.currentLanguage
  );

  const serviceContent = box.filter(
    (item) => item.title === translate('titleName.WeProvide') || item.title === translate('titleName.EngagementModel') || item.title === translate('titleName.Innovation') || item.title === translate('titleName.Domain')
  );

  useEffect(() => {
    getAllSection(currentLanguage).then((data) => {
      if (data && data.length > 0) {
        setBox(data);
      }
    });
  }, [currentLanguage]);

  return (
    <div className="App">
      <div className="service-page-banner">
        <h1 class="service-page-title">{translate('titleName.Services')}</h1>
        <img className="service-page-image" src={servicesBanner} alt=""></img>
      </div>
      {serviceContent.length > 0
        ? serviceContent.map((item, index) => (
            <Box
              key={index}
              description={item.description}
              name={item.name}
              title={item.title}
              items={item.items}
            />
          ))
        : null}
    </div>
  );
}

export default Service;