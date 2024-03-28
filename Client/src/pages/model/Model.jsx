import React, { useState, useEffect } from "react";
import Box from "../../components/box/Box";
import './Model.css';

import { getAllSection } from "../../api/ItemApi";
import { titleName } from "../../enum/EnumApi";
import { useSelector } from "react-redux";

function Model() {
  const [box, setBox] = useState([]);

  const data = require("../../imgURL.json");
  const servicesBanner = data.servicesBanner;

  const currentLanguage = useSelector(
    (state) => state.language.currentLanguage
  );

  const serviceContent = box.filter((item) => item.title === "ENGAGEMENT MODELS");

  useEffect(() => {
    getAllSection(currentLanguage).then((data) => {
      if (data && data.length > 0) {
        setBox(data);
      }
    });
  }, []);

  return (
    <div className="App">
      <div className="model-page-banner">
      <h1 className="model-page-title">ENGAGEMENT MODELS</h1>
      <img className="model-page-image" src={servicesBanner} alt=""></img>
    </div>
      {serviceContent.length > 0 ? serviceContent.map((item, index) => (
        <Box
          key={index}
          description={item.description}
          name={item.name}
          title={item.title}
          items={item.items}
        />
        )): null}
    </div>
  );
}

export default Model;
