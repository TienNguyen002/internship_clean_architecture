import React from 'react';
import './SideBar.css';
import { Link, useLocation } from 'react-router-dom';
import { sidebarLinks } from '../../../enum/EnumApi';

const SideBar = () => {
  const location = useLocation();

  return (
    <div className="sidebar">
      <ul>
        {sidebarLinks.map((link, index) => (
          <Link key={index} to={link.path}>
            <li className={location.pathname === link.path ? 'active ' + link.className : link.className}>
              {link.title}
            </li>
          </Link>
        ))}
      </ul>
    </div>
  );
};

export default SideBar;