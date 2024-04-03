import { Link } from "react-router-dom";
import { useTranslation } from 'react-i18next';
import "./NotFound.css"

const NotFound = () => {
  const data = require("../../imgURL.json");
  const servicesBanner = data.servicesBanner;
  const { t: translate } = useTranslation();

  return (
    <>
      <div className="service-page-banner">
        <img className="service-page-image" src={servicesBanner} alt=""></img>
      </div>
      <div className="not-found-container">
      <h1>{translate('notFound.Error')}</h1>
      <h2>{translate('notFound.ErrorInfo')}</h2>
      <h3>{translate('notFound.Detail')}</h3>
      <Link to="/"><button>{translate('notFound.BackHome')}</button></Link>
      </div>
    </>
  );
};

export default NotFound;
