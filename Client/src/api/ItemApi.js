import { delete_api, get_api, post_api } from "./method";
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

//get item with sectionSlug has pageSize and page Number
export function getItemBySectionSlug(payload) {
  return get_api(process.env.REACT_APP_API_PAGED_ITEM_URL + `?${convertObjToQueryString(payload)}`);
}

//get item by ID
export function getItemById(id) {
  return get_api(process.env.REACT_APP_API_ITEM_ID_URL + `${id}`);
}

//delete item by ID
export async function deleteItemById(id) {
  return delete_api(process.env.REACT_APP_API_ITEM_URL + `${id}`);
}

//create/update news
export async function editNews(formData){
  return post_api(process.env.REACT_APP_API_CREATE_NEWS_URL, formData)
}