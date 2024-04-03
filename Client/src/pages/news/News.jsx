import React, { useState, useEffect } from "react";
import Box from "../../components/box/Box";
import './News.css'

import { getAllSection } from "../../api/ItemApi";
import { useSelector } from "react-redux";
import { useTranslation } from 'react-i18next';

const News = () => {
  const [box, setBox] = useState([]);
  const { t: translate }  = useTranslation();

  const data = require("../../imgURL.json");
  const newsBanner = data.newsBanner;

  const currentLanguage = useSelector(
    (state) => state.language.currentLanguage
  );

  const newsContent = box.filter((item) => item.title === translate('titleName.News'));

  useEffect(() => {
    getAllSection(currentLanguage).then((data) => {
      if (data && data.length > 0) {
        setBox(data);
      }
    });
  }, [currentLanguage]);

  return (
    <div className="App">
    <div className="news-page-banner">
    <h1 class="news-page-title">{translate('titleName.News')}</h1>
    <img className="news-page-image" src={newsBanner} alt=""></img>
  </div>
    {newsContent.length > 0 ? newsContent.map((item, index) => (
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
};

export default News;
