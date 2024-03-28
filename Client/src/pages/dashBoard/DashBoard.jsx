import React from 'react';
import AdminNavbar from '../../components/admin/adminNavbar/AdminNavbar'; 
import SideBar from '../../components/admin/sideBar/SideBar';
import { Outlet } from 'react-router-dom';
import './DashBoard.css';

const DashBoard = () => {

  return (
    <div className="dashboard">
      <AdminNavbar />
      <div className="content">
        <div className='sidebar-content'>
        <SideBar />
        </div>
        <div className='outlet-content'>
        <Outlet/>
        </div>
      </div>
    </div>
  );
};

export default DashBoard;