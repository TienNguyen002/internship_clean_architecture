import React, { useState } from "react";
import { Link } from "react-router-dom";
import "../box/Box.css";
import { delaySlide, sectionName, sliderNumber } from "../../enum/EnumApi";
import { Swiper, SwiperSlide } from "swiper/react";
import "swiper/css";
import "swiper/css/pagination";
import { Autoplay, Pagination, Navigation } from "swiper/modules";
import DOMPurify from "dompurify";
import { convertDate } from "../../common/functions";

const BoxSlider = (props) => {
  const {
    slideNumber,
    switchNavigation,
    slideDelay,
    swiperStyle,
    items,
    itemStyle,
    titleItem,
    textBoxStyle,
    logoBoxStyle,
    hasBorder,
    hasSubTitle,
    sliderResponsive,
  } = props;
  return (
    <Swiper
      slidesPerView={slideNumber || sliderNumber.defaultSlideNumber}
      breakpoints={sliderResponsive}
      rewind={true}
      navigation={switchNavigation}
      autoplay={{
        pauseOnMouseEnter: true,
        delay: slideDelay || delaySlide.delay5s,
      }}
      modules={[Pagination, Navigation, Autoplay]}
    >
      {items.length > 0
        ? items.map((item, index) => (
            <SwiperSlide className={itemStyle || "box-item"} key={index}>
              <a className="link-to-index" href="/services">
                <div>
                  <img
                    className={logoBoxStyle || "item-logo"}
                    src={item.imageUrl}
                    alt=""
                  />
                </div>
                <h1 className={titleItem || "title-item"}>{item.title}</h1>
              </a>

              <div className={textBoxStyle || "item-text"}>
                {hasSubTitle ? (
                  <p>
                    {item.subTitle} - {convertDate(item.createdDate)}
                  </p>
                ) : null}
                {hasBorder ? (
                  <div className="desc-border">
                    <ul
                      dangerouslySetInnerHTML={{
                        __html: DOMPurify.sanitize(item.description),
                      }}
                    />
                  </div>
                ) : (
                  <p className="desc">
                    <p dangerouslySetInnerHTML={{
                        __html: DOMPurify.sanitize(item.description),
                      }}></p> <br />
                    {item.buttonStatus ? (
                      <Link to="/careers">
                      <button className="btn-lastestjobs">
                        {item.buttonLabel}
                      </button>
                      </Link>
                    ) : null}
                  </p>
                )}
              </div>
            </SwiperSlide>
          ))
        : null}
    </Swiper>
  );
};

export default BoxSlider;
