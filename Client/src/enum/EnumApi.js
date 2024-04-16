import { Quill } from "react-quill";
import CottageIcon from "@mui/icons-material/Cottage";
import NewspaperIcon from "@mui/icons-material/Newspaper";
import FeedIcon from "@mui/icons-material/Feed";
import FeedbackIcon from "@mui/icons-material/Feedback";

export const queryDefault = {
  sectionSlug: "",
  pageSizeDefault: 10,
  pageSizeDefaultNewsBlogs: 3,
  pageNumberDefault: 1,
  sortOrderASC: "ASC",
  sortOrderDESC: "DESC",
};

export const slugName = {
  logo: "navbar",
  banner: "banner",
  footer: "footer",
  news: "news",
  blogs: "blogs",
  navbar: "navbar",
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
  zero: 0,
  small: 1,
  medium: 5,
  large: 3,
  huge: 15,
  max: 100,
};

export const sectionName = {
  Domain: "Domains",
  Client: "Clients",
  Customer: "Customers",
  Recognized: "As Recognized By",
  New: "News",
  Blog: "Blogs",
  Model: "Models",
  LastestJobs: "Careers",
};

export const sidebarLinks = [
  { path: "/admin", title: "Home Page", icon: <CottageIcon /> },
  { path: "/admin/news", title: "News", icon: <NewspaperIcon /> },
  { path: "/admin/blogs", title: "Blogs", icon: <FeedIcon /> },
  { path: "/admin/request", title: "Requests", icon: <FeedbackIcon /> },
];

export const titleLinks = {
  "Services": {
    link: "/services",
  },
  "Domains": {
    link: "/services/domains",
  },
  "Innovations": {
    link: "/innovations",
  },
  "Models": {
    link: "/services/models",
  },
  "Clients": {
    link: "/customers",
  },
  "As Recognized By": {
    link: "",
  },
  "Careers": {
    link: "/careers",
  },
  "Customers": {
    link: "/customers/#testimonials",
  },
  "News": {
    link: "/news",
  },
  "Blogs": {
    link: "/blogs",
  },
  contactUs: "/contact-us"
};

export const sliderNumber = {
  oneSlideNumber: 1,
  defaultSlideNumber: 3,
  ourClientSlideNumber: 4,
  recognizedSlideNumber: 5,
};

export const sliderResponsive = {
  DefaultBreakpoints: {
    0: {
      slidesPerView: 1,
    },
    480: {
      slidesPerView: 1,
    },
    768: {
      slidesPerView: 2,
    },
    980: {
      slidesPerView: 3,
    },
  },
  DomainBreakpoints: {
    0: {
      slidesPerView: 1,
    },
    480: {
      slidesPerView: 1,
    },
    768: {
      slidesPerView: 2,
    },
    980: {
      slidesPerView: 3,
    },
  },
  ClientsBreakpoints: {
    0: {
      slidesPerView: 1,
    },
    480: {
      slidesPerView: 2,
    },
    768: {
      slidesPerView: 3,
    },
    980: {
      slidesPerView: 4,
    },
  },
  RecognizedBreakpoints: {
    0: {
      slidesPerView: 2,
    },
    480: {
      slidesPerView: 3,
    },
    768: {
      slidesPerView: 4,
    },
    980: {
      slidesPerView: 5,
    },
  },
  OneItemBreakpoints: {
    0: {
      slidesPerView: 1,
    },
  },
};

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
    titleStyle: "outclient-title",
  },
  "As Recognized By": {
    boxBody: "home-recognized-box",
    boxContainer: "container-recognized",
    titleStyle: "recognized-title",
    boxdesc: "hidden",
  },
  "Customers": {
    boxBody: "box-body-customer",
  },
  "News": {
    boxBody: "box-body-news-blog",
  },
  "Blogs": {
    boxBody: "box-body-news-blog",
  }
};

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

export const btnValue = {
  variant: "outlined",
  sizeM: "medium",
  colorErr: "error",
  colorSuccess: "success",
  typeSubmit: "submit",
  colorAdd: "primary"
};
export const editModules = {
  toolbar: [
    [{ header: "1" }, { header: "2" }, { font: [] }],
    [{ size: [] }],
    ["bold", "italic", "underline", "strike", "blockquote"],
    [
      { list: "ordered" },
      { list: "bullet" },
      { indent: "-1" },
      { indent: "+1" },
    ],
    ["link", "image", "video"],
    ["clean"],
  ],
  clipboard: {
    matchVisual: false,
  },
  imageResize: {
    parchment: Quill.import("parchment"),
    modules: ["Resize", "DisplaySize"],
  },
};
export const editFormats = [
  "header",
  "font",
  "size",
  "bold",
  "italic",
  "underline",
  "strike",
  "blockquote",
  "list",
  "bullet",
  "indent",
  "link",
  "image",
  "video",
]

export const deleteForm = {
  title: "Do you want to delete?",
  text: "This cannot reverse!",
  icon: "error",
  confirmBtnColor: "#3085d6",
  cancelBtnColor: "#d33",
  confirmBtnDelete: "DELETE",
  resultTitle: "DELETED",
  resultIcon: "success",
};

export const styleDrawer = {
  drawerWidth: 240,
  color: "inherit",
  ariaLabel: "open drawer",
  edge: "start",

  styleDrawerHeader: {
    minHeight: 48,
    ml: "auto",
    justifyContent: "center",
    gap: 18,
  },
  styleListItem: {
    display: "block"
  },
  dNone: "none",
  dBlock: "block",
  styleListItemButton: {
    minHeight: 48,
    px: 2.5,
  }
};

export const widthTable = {
  ss: 100,
  s: 200,
  md: 300,
  l: 400,
  xl: 500,
}

export const timeout = {
  quick: 50,
}