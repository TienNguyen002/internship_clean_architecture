import { linkSocial } from "../enum/EnumApi";

/**
 * Converts an object into a query string format.
 *
 * @param {Object} obj The object to convert into a query string.
 * @return {string} A string representing the query string.
 */
export const convertObjToQueryString = function(obj) {
    var str = [];
    for (var p in obj)
      if (obj.hasOwnProperty(p)) {
        str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
      }
    return str.join("&");
}

/**
 * Converts an object into a string representation.
 *
 * @param {Object} obj The object to convert into a string.
 * @return {string} A string representing the object.
 */
export const queryString = function(obj) {
  var str = [];
  for (var p in obj)
    if (obj.hasOwnProperty(p)) {
      str.push(encodeURIComponent(obj[p]));
    }
  return str.join("/");
}

/**
 * Converts a date string into a formatted date.
 *
 * @param {string} inputDate The date string to convert.
 * @return {string} A formatted date string in the format "dd/mm/yyyy".
 */
export const convertDate = (inputDate) => {
  let date = new Date(inputDate);

  let year = date.getFullYear();
  let month = date.getMonth() + 1;
  let day = date.getDate();

  return day + '/' + month + '/' + year;
}


/**
 * Splits a URL and returns the last three segments joined by a forward slash.
 *
 * @param {string} url The URL to split.
 * @return {string} The last three segments of the URL joined by a forward slash.
 */
export const splitUrl = (url) => {
  url.split("/").slice(-3).join("/")
}

/**
 * Splits a URL and returns the icon part based on the provided social media link.
 *
 * @param {string} url The social media link.
 * @return {string} The icon part of the URL.
 */
export const splitIcon = (url) => {
  return (
    url === linkSocial.twitter ?
    url.split("//")[1].split(".")[0]
    : url.split("/").slice(-3).join("/").split(".")[1]
  )
}