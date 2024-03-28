export const queryDefault = {
  sectionSlug: "",
  pageSizeDefault: 10,
  pageNumberDefault: 1,
  sortOrderASC: "ASC",
  sortOrderDESC: "DESC",
};

export const slugName = {
  logo: "logo",
  banner: "banner",
  footer: "footer",
};

export const language = {
  english: "en",
  japanese: "ja",
};

export const delaySlide = {
  delay3s: 3000,
  delay5s: 5000,
};

export const numberLength = {
  zero :0,
  small: 1,
  medium: 5,
  large: 3,
  huge: 15,
};

export const sectionName = {
  Domain: "Domains",
  Client: "Clients",
  Customer: "Customers",
  Recognized: "As Recognized By",
  New: "News",
  Blog: "Blogs",
  Model: "Models",
  LastestJobs: "Careers"
};

export const titleName = {
  WeProvide:"WE PROVIDE",
  EngagementModel:"ENGAGEMENT MODELS",
  Innovation:"INNOVATIONS",
  Domain:"DOMAINS & TECHNOLOGIES"
};

export const sidebarLinks = [
  { path: '/admin', title: 'Dashboard', className: 'large' },
  { path: '/admin/', title: 'HomePage', className: 'large' },
  { path: '/admin/news', title: 'News' },
  { path: '/admin/blogs', title: 'Blogs' },
];

export const sliderNumber = {
  oneSlideNumber : 1,
  defaultSlideNumber : 3,
  ourClientSlideNumber : 4,
  recognizedSlideNumber : 5
}

export const boxSliderClassNameConfig = {
  "Domains": {
    boxBody: "box-home-body-domain",
    boxdesc: "hidden",
    titleStyle: "domain-title",
  },
  "Clients": {
    boxBody: "box-home-body-outclient",
    boxContainer: "container-outclient",
    boxdesc: "hidden",
    titleStyle: "outclient-title"
  },
  "As Recognized By": {
    boxBody: "home-recognized-box",
    boxContainer: "container-recognized",
    titleStyle: "recognized-title",
    boxdesc: "hidden"
  },
  "Customers": {
    boxBody: "box-body-customer"
  }
}

export const error = {
  tooShort: "Too short",
};

export const formData = {
  name: "",
  email: "",
  phone: "",
  subject: "",
  message: "",
};