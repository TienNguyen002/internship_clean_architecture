
import './App.css';
import { Routes,Route } from 'react-router-dom';
import { routes, adminRoutes } from './router/Routes'; 
import DashBoard from "./pages/dashBoard/DashBoard";
import Layout from './components/layout/Layout';

function App() {
  return (
    <Routes>
    <Route path="/" element={<Layout />}>
      {routes.map((route, index) => (
        <Route key={index} path={route.path} element={route.element} />
      ))}
    </Route>

    <Route path="/admin/" element={<DashBoard />}>
      {adminRoutes.map((route, index) => (
        <Route key={index} path={route.path} element={route.element} />
      ))}
    </Route>
  </Routes>
  );
}

export default App;
