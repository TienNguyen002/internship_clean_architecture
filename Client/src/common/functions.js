export const convertObjToQueryString = function(obj) {
    var str = [];
    for (var p in obj)
      if (obj.hasOwnProperty(p)) {
        str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
      }
    return str.join("&");
}

export const queryString = function(obj) {
  var str = [];
  for (var p in obj)
    if (obj.hasOwnProperty(p)) {
      str.push(encodeURIComponent(obj[p]));
    }
  return str.join("/");
}

export const convertDate = (inputDate) => {
  let date = new Date(inputDate);

  let year = date.getFullYear();
  let month = date.getMonth() + 1;
  let day = date.getDate();

  return day + '/' + month + '/' + year;
}