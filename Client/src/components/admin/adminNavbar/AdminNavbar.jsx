import React from 'react';
import './AdminNavbar.css';
import { Link } from 'react-router-dom';

const data = require("../../../imgURL.json"); 
const adminLogo = data.adminLogo;

const AdminNavbar = () => {
  return (
    <div className="admin-navbar">
      <div className='admin-logo-container'>
        <Link to="/">
        <img className='admin-logo' src={adminLogo} alt="" />
        </Link>
      </div>
      <div className='admin-left-icons'>
        <form className='admin-search-form'>
          <input type="text" placeholder="Tìm kiếm..." />
          <button type="submit"><i className="fa-solid fa-search"></i></button>
        </form>
      </div>
      <div className='admin-right-icons'>
        <i className="fa-solid fa-user-circle"></i>
      </div>
    </div>
  );
}

export default AdminNavbar;