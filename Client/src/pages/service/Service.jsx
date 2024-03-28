import React, { useState, useEffect } from "react";
import Box from "../../components/box/Box";
import './Service.css'

import { getAllSection } from "../../api/ItemApi";
import { titleName } from "../../enum/EnumApi";
import { useSelector } from "react-redux";

function Service() {
  const [box, setBox] = useState([]);

  const data = require("../../imgURL.json");
  const servicesBanner = data.servicesBanner;

  const currentLanguage = useSelector(
    (state) => state.language.currentLanguage
  );

  const serviceContent = box.filter(
    (item) => item.title === titleName.WeProvide || item.title === titleName.EngagementModel || item.title === titleName.Innovation || item.title === titleName.Domain 
  );

  useEffect(() => {
    getAllSection(currentLanguage).then((data) => {
      if (data && data.length > 0) {
        setBox(data);
      }
    });
  }, []);

  return (
    <div className="App">
      <div className="service-page-banner">
        <h1 class="service-page-title">Services</h1>
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