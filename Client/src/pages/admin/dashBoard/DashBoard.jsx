import React from "react";
import Box from '@mui/material/Box';
import "./DashBoard.css";
import Sidebar from "../../../components/admin/sideBar/SideBar";

const DashBoard = () => {
  return (
    <>
    <Box sx={{ padding: 10, display: 'flex' }}>
      <Sidebar />
      <Box component="main" sx={{ flexGrow: 1, p: 3 }}>
        <h1>Home</h1>
      </Box>
    </Box>
    </>
  );
};

export default DashBoard;
