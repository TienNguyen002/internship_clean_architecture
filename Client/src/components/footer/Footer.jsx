import React, { useState, useEffect } from "react";
import { getFooter, getSectionBySlug } from "../../api/ItemApi";
import { slugName, footerName, language } from "../../enum/EnumApi";

import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faLocationDot } from "@fortawesome/free-solid-svg-icons";
import { useTranslation } from 'react-i18next';
import { Link } from "react-router-dom";

import "./Footer.css";

const Footer = (props) => {
  const [footer, setFooter] = useState([]);
  const [isActive, setIsActive] = useState(false);
  const data = require("../../imgURL.json"); // read file JSON
  const upTop = data.upTop; // Get the value "upTop" from the JSON file
  const googleMap = data.googleMap;
  const { locale } = props;
  const { t: translate }  = useTranslation();
  
  const scrollToTop = () => {
    window.scrollTo({ top: 0, behavior: "smooth" });
  };

  const toggleMap = () => {
    setIsActive(!isActive);
  };

  useEffect(() => {
    getFooter(locale).then((data) => {
      if (data) {
        setFooter(data.items);
      } else setFooter([]);
    });
  }, [locale]);
  const footerOffice = footer.filter(
    (item) =>
      item.title === translate('footer.Headquarters') ||
      item.title === translate('footer.Branchoffice')
  );
  const footerContent = footer.filter(
    (item) =>
      item.title === translate('footer.GeneralInquiries') ||
      item.title === translate('footer.SaleSupport')
  );
  const footerCopyright = footer.filter(
    (item) => item.title === translate('footer.Copyright')
  );
  const footerSocial = footer.filter(
    (item) =>
      item.title ===  translate('footer.ConnectWithUs')
  );

  return (
    <div className="site-footer">
      <div className="box-footer-google">
        <div className="footer-container">
          <div className="box-footer-google-title">
            <Link to="contact-us"><a>{translate("footer.Contact")}</a></Link>
          </div>
          <div className="box-footer-google-description">
            <a onClick={toggleMap}>
              {translate('footer.Map')}
              <FontAwesomeIcon className="location-icon" icon={faLocationDot} />
              <img src="" />
            </a>
          </div>
        </div>
      </div>

      <div className="map-container">
        <div className={`map-show ${isActive ? "active" : ""}`}>
          <iframe
            src={googleMap}
            height="450px"
            width="100%"
            allowFullScreen=""
            loading="lazy"
            style={{ border: "0" }}
          ></iframe>
        </div>
      </div>

      <div className="box-footer-location">
        <div className="footer-container">
          {footerOffice.length > 0
            ? footerOffice.map((item, index) => (
                <div className="footer-item" key={index}>
                  <h3>{item.title}:</h3>
                  <p>{item.address}</p>
                  <a>{item.telNumber}</a>
                </div>
              ))
            : null}
        </div>
      </div>

      <div className="box-footer-support">
        <div className="footer-container">
          {footerContent.length > 0
            ? footerContent.map((item, index) => (
                <div className="footer-item" key={index}>
                  <h3>{item.title}:</h3>
                  {item.subItems.length > 0
                    ? item.subItems.map((subitem, index) => (
                        <div className="space-item" key={index}>
                          <a href="">
                            <img
                              src={subitem.image.imageUrl}
                              className="mail-icon"
                            />
                            <span className="space-item-text">
                              {" "}
                              {subitem.text}
                            </span>
                          </a>
                        </div>
                      ))
                    : null}
                </div>
              ))
            : null}
        </div>
      </div>

      <div className="box-footer-bottom">
        <div className="footer-container">
          {footerCopyright.length > 0
            ? footerCopyright.map((item, index) => (
                <div className="box-footer-bottom-copyright" key={index}>
                  {item.description}
                </div>
              ))
            : null}
          {footerSocial.length > 0
            ? footerSocial.map((item, index) => (
                <div className="box-footer-bottom-socials" key={index}>
                  {item.title}
                  {item.subItems.length > 0
                    ? item.subItems.map((subitem, index) => (
                        <a
                          href={subitem.image.hyperlink}
                          target="_blank"
                          rel="noopener noreferrer"
                          key={index}
                        >
                          <img
                            src={subitem.image.imageUrl}
                            className="socials-icon"
                          />
                        </a>
                      ))
                    : null}
                  <img
                    className="scroll-to-top"
                    onClick={scrollToTop}
                    id="back-to-top"
                    src={upTop}
                  ></img>
                </div>
              ))
            : null}
        </div>
      </div>
    </div>
  );
};

export default Footer;
