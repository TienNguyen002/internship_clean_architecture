import React from 'react'
import './Blog.css'

const Blog = () => {
    const data = require("../../imgURL.json");
    const servicesBanner = data.servicesBanner;
  return (
    <div className="blog-page-banner">
    <img className="blog-page-image" src={servicesBanner} alt=""></img>
  </div>
  )
}

export default Blog