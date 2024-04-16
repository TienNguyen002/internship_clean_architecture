import HomePage from "../pages/HomePage";
import Career from '../pages/career/Career';
import Service from '../pages/service/Service';
import Innovation from "../pages/innovation/Innovation";
import Model from '../pages/model/Model';
import Domain from "../pages/domain/Domain";
import Customer from "../pages/customer/Customer";
import News from "../pages/news/News";
import Blog from "../pages/blog/Blog";
import ContactUs from "../pages/contactUs/ContactUs";
import AboutUs from "../pages/aboutUs/AboutUs";
import BadRequest from "../pages/badRequest/BadRequest";
import NotFound from "../pages/notFound/NotFound";
import AdNews from '../pages/admin/news/News';
import AdBlogs from "../pages/admin/blogs/Blogs";
import DashBoard from "../pages/admin/dashBoard/DashBoard";
import AdRequest from "../pages/admin/requests/Request";

export const routes = [
  { path: "/", element: <HomePage /> },
  { path: "/home/", element: <HomePage /> },
  { path: "/careers/", element: <Career /> },
  { path: "/news/", element: <News /> },
  { path: "/news/page/:pageNumber", element:<News/>},
  { path: "/blogs/", element: <Blog /> },
  { path: "/blogs/page/:pageNumber", element:<Blog/>},
  { path: "/services", element: <Service /> },
  { path: "/contact-us", element: <ContactUs /> },
  { path: "/about-us", element: <AboutUs /> },
  { path: "/innovations", element: <Innovation /> },
  { path: "/customers", element: <Customer /> },
  { path: "/services/models", element: <Model /> },
  { path: "/services/domains", element: <Domain /> },
  { path: "/400/", element: <BadRequest /> },
  { path: "*", element: <NotFound /> }
];

export const adminRoutes = [
  { path: "/admin", element: <DashBoard /> },
  { path: `/admin/news`, element: <AdNews /> },
  { path: "/admin/blogs", element: <AdBlogs /> },
  { path: "/admin/request", element: <AdRequest /> },
];