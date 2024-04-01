import HomePage from "../pages/HomePage";
import Career from '../pages/career/Career';
import Service from '../pages/service/Service';
import Model from '../pages/model/Model';
import BadRequest from "../pages/BadRequest";
import NotFound from "../pages/NotFound";
import News from '../pages/admin/news/News';
import Blogs from "../pages/admin/blogs/Blogs";
import Edit from "../components/admin/edit/Edit";

export const routes = [
  { path: "/", element: <HomePage /> },
  { path: "/home/", element: <HomePage /> },
  { path: "/career/", element: <Career /> },
  { path: "/services/", element: <Service /> },
  { path: "/services/models", element: <Model /> },
  { path: "/400/", element: <BadRequest /> },
  { path: "*", element: <NotFound /> }
];

export const adminRoutes = [
  { path: "/admin/news", element: <News /> },
  { path: "/admin/blogs", element: <Blogs /> },
  { path: "/admin/news/edit", element: <Edit/> },
  { path: "/admin/news/edit/:id", element: <Edit/> },
  { path: "/admin/blogs/edit", element: <Edit/> },

];