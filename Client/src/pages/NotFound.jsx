import { Link } from "react-router-dom";

const NotFound = () => {
  const data = require("../imgURL.json");
  const servicesBanner = data.servicesBanner;

  return (
    <>
      <div className="service-page-banner">
        <img className="service-page-image" src={servicesBanner} alt=""></img>
      </div>
      <h1>404 - Page Not Found</h1>
      <h2>The page you are looking for might have been removed</h2>
      <h3>had its name changed or is temporarily unavailable</h3>
      <Link to="/">Go to homepage</Link>
    </>
  );
};

export default NotFound;