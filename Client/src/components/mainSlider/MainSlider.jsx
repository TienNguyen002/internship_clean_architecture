import React, { useState, useEffect } from "react";
import { useSelector } from "react-redux";
import { getItemByCategory } from "../../api/ItemApi";

// Import Swiper React components
import { Swiper, SwiperSlide } from "swiper/react";
// Import Swiper styles
import "swiper/css";
import "swiper/css/pagination";
import "swiper/css/navigation";

import "./MainSlider.css";

// import required modules
import { Autoplay, Pagination, Navigation } from "swiper/modules";
import { slugName, delaySlide } from "../../enum/EnumApi";

export default function MainSlider(props) {
  const [banner, setBanner] = useState([]);
  const currentLanguage = useSelector(
    (state) => state.language.currentLanguage
  );
  const payload = {
    categorySlug: slugName.banner,
    language: currentLanguage,
  };

  useEffect(() => {
    getItemByCategory(payload).then((data) => {
      if (data) {
        setBanner(data);
      } else setBanner([]);
    });
  }, [currentLanguage]);
  return (
    <>
      <div>
        <Swiper
          loop={true}
          autoplay={{
            delay: delaySlide ? delaySlide.delay3s : null,
            disableOnInteraction: false,
            pauseOnMouseEnter: true,
          }}
          pagination={{
            type: "fraction",
          }}
          navigation={true}
          modules={[Autoplay, Pagination, Navigation]}
          className="main-slider-swiper"
        >
          {banner.length > 0
            ? banner.map((item, index) => (
                <SwiperSlide className="banner" key={index}>
                  <img className="banner-img" src={item.imageUrl} alt="" />
                  <div className="text_main_slide">
                    <a className="title_main_slide">
                      <strong>{item.boldTitle}</strong>
                      {item.title}
                    </a>
                    <p className="description_main_slide">{item.description}</p>
                  </div>
                </SwiperSlide>
              ))
            : null}
        </Swiper>
      </div>
    </>
  );
}