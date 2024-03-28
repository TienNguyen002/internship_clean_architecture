import { Link } from "react-router-dom";

const BadRequest = () => {
  const data = require("../imgURL.json");
  const servicesBanner = data.servicesBanner;

  return (
    <>
      <div className="service-page-banner">
        <img className="service-page-image" src={servicesBanner} alt=""></img>
      </div>
      <h1>400 - Bad Request</h1>
      <h2>Invalid Request</h2>
      <h3>It seems the parameters in your URL are not correct</h3>
      <Link to="/">Go To Homepage</Link>
    </>
  );
};

export default BadRequest;