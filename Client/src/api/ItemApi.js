import { get_api, post_api } from "./method";
import { convertObjToQueryString, queryString } from "../common/functions";

export function getItemByCategory(payload) {
  return get_api(process.env.REACT_APP_API_ITEM_URL + `${queryString(payload)}`);
}
export function getAllSection(language) {
  return get_api(process.env.REACT_APP_API_SECTION_URL + `/${language}`);
}
export function getRequestForm(language) {
  return get_api(process.env.REACT_APP_API_REQUEST_URL + `/${language}`);
}

export function postRequestForm(formData){
  return post_api(process.env.REACT_APP_API_POST_REQUEST_URL, formData)
}

export function getFooter(language) {
    return get_api(process.env.REACT_APP_API_FOOTER_URL + `/${language}`);
}