import React, { useState, useEffect } from "react";
import Box from "@mui/material/Box";
import EditIcon from "@mui/icons-material/Edit";
import DeleteIcon from "@mui/icons-material/DeleteOutlined";
import VisibilityIcon from '@mui/icons-material/Visibility';
import { useDemoData } from "@mui/x-data-grid-generator";
import {
  DataGrid,
  GridToolbarContainer,
  GridActionsCellItem,
  GridRowEditStopReasons,
  GridToolbarQuickFilter,
} from "@mui/x-data-grid";
import { getAllSection, deleteSectionById } from "../../../api/ItemApi";
import {
  deleteForm,
  widthTable,
} from "../../../enum/EnumApi";
import Swal from "sweetalert2";
import "../../../components/admin/table/Table.css";
import SideBar from "../../../components/admin/sideBar/SideBar";
import { useSelector } from "react-redux";
import EditSection from "../../../components/admin/edit/EditSection";
import "./Section.css";
import { Link } from "react-router-dom";

export default function Section() {
  const [rows, setRows] = useState([]);
  const [idEdit, setIdEdit] = useState();
  const [rowModesModel, setRowModesModel] = useState({});
  const [isPopupVisible, setIsPopupVisible] = useState(false);
  const currentLanguage = useSelector(
    (state) => state.language.currentLanguage
  );
  const payload = {
    locale: currentLanguage
  }

  //call api get data
  useEffect(() => {
    setIdEdit(1);
    getItem();
    async function getItem() {
      const data = await getAllSection(payload);
      if (data) {
        setRows(data);
        console.log(data);
      } else setRows([rows.id]);
    }
  }, [rows.id, currentLanguage]);

  const { data } = useDemoData({
    dataSet: "Commodity",
  });
  const handleRowEditStop = (params, event) => {
    if (params.reason === GridRowEditStopReasons.rowFocusOut) {
      event.defaultMuiPrevented = true;
    }
  };

  const togglePopup = () => {
    setIsPopupVisible(true);
  };

  const handleEditClick = (id) => () => {
    togglePopup(true);
    setIdEdit(id);
  };

  const handleDeleteClick = (id) => () => {
    Remove(id);
    async function Remove(id) {
      Swal.fire({
        title: deleteForm.title,
        text: deleteForm.text,
        icon: deleteForm.icon,
        showCancelButton: true,
        confirmButtonColor: deleteForm.confirmBtnColor,
        cancelButtonColor: deleteForm.cancelBtnColor,
        confirmButtonText: deleteForm.confirmBtnDelete,
      }).then((result) => {
        if (result.isConfirmed) {
          deleteSectionById(id);
          setRows(rows.filter((row) => row.id !== id));
          Swal.fire({
            title: deleteForm.resultTitle,
            icon: deleteForm.resultIcon,
          });
        }
      });
    }
  };

  const getActions = ({ id }) => {
    return [
      <GridActionsCellItem
        icon={<EditIcon />}
        label="Edit"
        className="textPrimary"
        onClick={handleEditClick(id)}
        color="inherit"
      />,
      <GridActionsCellItem
        icon={<DeleteIcon />}
        label="Delete"
        onClick={handleDeleteClick(id)}
        color="inherit"
      />
    ];
  };

  const processRowUpdate = (newRow) => {
    const updatedRow = { ...newRow, isNew: false };
    setRows(rows.map((row) => (row.id === newRow.id ? updatedRow : row)));
    return updatedRow;
  };

  const handleRowModesModelChange = (newRowModesModel) => {
    setRowModesModel(newRowModesModel);
  };

  const columns = [
    {
      field: "backgroundUrl",
      headerName: "Background",
      minWidth: widthTable.m,
      maxWidth: widthTable.l,
      flex: 1,
      renderCell: (rows) => (
        <img className="imageUrl-table" src={rows.value} alt="" />
      ),
    },
    {
      field: "title",
      headerName: "Title",
      type: "text",
      minWidth: widthTable.xs,
      maxWidth: widthTable.l,
      flex: 1,
      align: "left",
      headerAlign: "left",
    },
    {
      field: "description",
      headerName: "Description",
      type: "text",
      minWidth: widthTable.xs,
      maxWidth: widthTable.xl,
      flex: 1,
      align: "left",
      headerAlign: "left",
    },
    {
      field: "actions",
      type: "actions",
      headerName: "Actions",
      cellClassName: "actions",
      getActions,
      minWidth: widthTable.ss,
      maxWidth: widthTable.s,
      flex: 1,
    },
    {
      field: "urlSlug",
      type: "text",
      headerName: `See Items`,
      renderCell: (params) => (
        <>
          <Link className="seeItems" to={`/admin/${params.value}`}>
            <VisibilityIcon />
          </Link>
        </>
      ),
      minWidth: widthTable.ss,
      maxWidth: widthTable.s,
      flex: 1,
    },
  ];

  return (
    <Box className="sections-admin" sx={{ display: "flex" }}>
      <SideBar name="Section" />
      <Box
        component="main"
        sx={{
          padding: 10,
          maxHeight: "100vh",
          height: "fit-content",
          width: "100%",
          "& .actions": {
            color: "text.secondary",
          },
          "& .textPrimary": {
            color: "text.primary",
          },
          display: "table",
          tableLayout: "fixed",
        }}
      >
        <div className="data-grid-container">
          <DataGrid
            getRowHeight={() => "auto"}
            rows={rows}
            columns={columns}
            rowModesModel={rowModesModel}
            onRowModesModelChange={handleRowModesModelChange}
            onRowEditStop={handleRowEditStop}
            processRowUpdate={processRowUpdate}
            slots={{
              toolbar: HandleToolbar,
            }}
            initialState={{
              ...data.initialState,
              pagination: { paginationModel: { pageSize: 20 } },
            }}
            pageSizeOptions={[5, 10, 25]}
            slotProps={{
              toolbar: { setRows, setRowModesModel },
            }}
          />
        </div>
      </Box>
      <div className={`edit-show ${isPopupVisible ? "active" : ""}`}>
        <EditSection
          id={idEdit}
          setRows={setRows}
          setIsPopupVisible={setIsPopupVisible}
          currentLanguage={currentLanguage}
        />
      </div>
    </Box>
  );
  function HandleToolbar() {
    return (
      <GridToolbarContainer sx={{ justifyContent: "space-between" }}>
        <GridToolbarQuickFilter />
      </GridToolbarContainer>
    );
  }
}
