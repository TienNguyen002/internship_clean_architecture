import { delete_api, get_api, post_api, upload_image } from "./method";
import { convertObjToQueryString, queryString } from "../common/functions";

/**
 * Retrieves items based on the provided category payload.
 *
 * @param {Object} payload The payload containing parameters for the request.
 * @return {Promise} A promise resolving to the response from the API.
 */
export function getItemByCategory(payload) {
  return get_api(process.env.REACT_APP_API_ITEM_URL + `${queryString(payload)}`);
}

/**
 * Retrieves all sections for a given language.
 *
 * @param {string} language The language for which to retrieve sections.
 * @return {Promise} A promise resolving to the response from the API.
 */
export function getAllSection(language) {
  return get_api(process.env.REACT_APP_API_SECTION_URL + `/${language}`);
}

/**
 * Retrieves a request form for a given language.
 *
 * @param {string} language The language for which to retrieve the request form.
 * @return {Promise} A promise resolving to the response from the API.
 */
export function getRequestForm(language) {
  return get_api(process.env.REACT_APP_API_REQUEST_URL + `/${language}`);
}

/**
 * Posts a request form using the provided form data.
 *
 * @param {FormData} formData The form data containing the request details.
 * @return {Promise} A promise resolving to the response from the API.
 */
export function postRequestForm(formData){
  return post_api(process.env.REACT_APP_API_POST_REQUEST_URL, formData)
}

/**
 * Retrieves the footer content for a given language.
 *
 * @param {string} language The language for which to retrieve the footer content.
 * @return {Promise} A promise resolving to the response from the API.
 */
export function getFooter(language) {
    return get_api(process.env.REACT_APP_API_FOOTER_URL + `/${language}`);
}

/**
 * Retrieves items based on the section slug, page size, and page number.
 *
 * @param {Object} payload The payload containing parameters for the request.
 * @return {Promise} A promise resolving to the response from the API.
 */
export function getItemBySectionSlug(payload) {
  return get_api(process.env.REACT_APP_API_PAGED_ITEM_URL + `?${convertObjToQueryString(payload)}`);
}

/**
 * Retrieves an item by its ID.
 *
 * @param {string} id The ID of the item to retrieve.
 * @return {Promise} A promise resolving to the response from the API.
 */
export function getItemById(id) {
  return get_api(process.env.REACT_APP_API_ITEM_ID_URL + `${id}`);
}

/**
 * Deletes an item by its ID.
 *
 * @param {string} id The ID of the item to delete.
 * @return {Promise} A promise resolving to the response from the API.
 */
export function deleteItemById(id) {
  return delete_api(process.env.REACT_APP_API_ITEM_URL + `${id}`);
}

/**
 * Calls the API to delete a contact by its ID.
 *
 * @param {string} id The ID of the contact to be deleted.
 * @return {Promise} A promise resolving to the response from the API.
 */
export function deleteContactById(id) {
  return delete_api(process.env.REACT_APP_API_POST_REQUEST_URL + `/${id}`);
}

/**
 * Creates or updates news using the provided form data.
 *
 * @param {FormData} formData The form data containing the news details.
 * @return {Promise} A promise resolving to the response from the API.
 */
export function editNews(formData){
  return post_api(process.env.REACT_APP_API_CREATE_NEWS_URL, formData)
}

/**
 * Creates or updates a blog using the provided form data.
 *
 * @param {FormData} formData The form data containing the blog details.
 * @return {Promise} A promise resolving to the response from the API.
 */
export function   editBlog(formData){
  return post_api(process.env.REACT_APP_API_CREATE_BLOG_URL, formData)
}

/**
 * Calls the API to retrieve contacts based on the provided payload.
 *
 * @param {Object} payload The payload containing parameters for the request.
 * @return {Promise} A promise resolving to the response from the API.
 */
export function getContact(payload){
  return get_api(process.env.REACT_APP_API_POST_REQUEST_URL + `?${convertObjToQueryString(payload)}`)
}

/**
 * Uploads a file to Cloudinary using the provided form data.
 *
 * @param {FormData} formData The form data containing the file to upload.
 * @return {Promise} A promise resolving to the response from Cloudinary.
 */
export function uploadToCloudinary(formData){
    return post_api(process.env.REACT_APP_CLOUDINARY_NAME, formData)
};

/**
 * Uploads an image file to Cloudinary.
 *
 * @param {File} file The image file to upload.
 * @return {Promise} A promise resolving to the response from Cloudinary.
 */
export function uploadImageEditor(file){
  return upload_image(process.env.REACT_APP_CLOUDINARY_NAME, file)
};