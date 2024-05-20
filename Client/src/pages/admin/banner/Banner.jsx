import React, { useState, useEffect } from "react";
import Box from "@mui/material/Box";
import Button from "@mui/material/Button";
import AddIcon from "@mui/icons-material/Add";
import EditIcon from "@mui/icons-material/Edit";
import DeleteIcon from "@mui/icons-material/DeleteOutlined";
import {
  DataGrid,
  GridToolbarContainer,
  GridActionsCellItem,
  GridRowEditStopReasons,
  GridToolbarQuickFilter,
} from "@mui/x-data-grid";
import { getItemByCategory, deleteItemById, changeDisplay } from "../../../api/ItemApi";
import {
  SwalEnum,
  btnValue,
  deleteForm,
  slugName,
  widthTable,
} from "../../../enum/EnumApi";
import Swal from "sweetalert2";
import "../../../components/admin/table/Table.css";
import EditBanner from "../../../components/admin/edit/EditBanner";
import SideBar from "../../../components/admin/sideBar/SideBar";
import "./Banner.css"
import { useSelector } from "react-redux";
import Checkbox from '@mui/material/Checkbox';
import { toast, Toaster } from "react-hot-toast";

export default function Banner() {
  const [rows, setRows] = useState([]);
  const [idEdit, setIdEdit] = useState();
  const [rowModesModel, setRowModesModel] = useState({});
  const [isPopupVisible, setIsPopupVisible] = useState(false);
  const [rowSelectionModel, setRowSelectionModel] = useState();
  const currentLanguage = useSelector(
    (state) => state.language.currentLanguage
    );
    const payload = {
      categorySlug: slugName.banner,
      Locale: currentLanguage,
    };

  //call api get data
  useEffect(() => {
    getItem();
    async function getItem() {
      const data = await getItemByCategory(payload);
      if (data) {
        setRows(data);
      } else setRows([rows.id]);
    }
  }, [rows.id, currentLanguage, rowSelectionModel]);

  const handleRowEditStop = (params, event) => {
    if (params.reason === GridRowEditStopReasons.rowFocusOut) {
      event.defaultMuiPrevented = true;
    }
  };

  const togglePopup = () => {
    setIsPopupVisible(true);
  };

  const handleAddClick = () => {
    setIdEdit(0);
    togglePopup(true);
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
          deleteItemById(id);
          setRows(rows.filter((row) => row.id !== id));
          Swal.fire({
            title: deleteForm.resultTitle,
            icon: deleteForm.resultIcon,
          });
        }
      });
    }
  };

  const handleDisplay = (id, value) => {
    changeDisplay(id).then((data) => {
      if (value === false) {
        setRowSelectionModel(!rowSelectionModel);
        return toast.success(SwalEnum.displayedSuccessOn);
      } else if(value === true){
        setRowSelectionModel(!rowSelectionModel);
        return toast.success(SwalEnum.displayedSuccessOff);
      }else{
        return toast.error(SwalEnum.displayedError);
      }
    });
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
      />,
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
      field: "isDisplayed",
      headerName: "Display on Home Page",
      minWidth: widthTable.ss,
      maxWidth: widthTable.m,
      flex: 1,
      renderCell: ({id, value}) => (
        <Checkbox
          checked={value}
          onChange={() => handleDisplay(id, value)}
        />
      ),
    },
    {
      field: "imageUrl",
      headerName: "Image",
      minWidth: widthTable.m,
      maxWidth: widthTable.l,
      flex: 1,
      renderCell: (rows) => <img className="imageUrl-table" src={rows.value} />,
    },
    {
      field: "boldTitle",
      headerName: "Bold Title",
      type: "text",
      minWidth: widthTable.m,
      maxWidth: widthTable.l,
      flex: 1,
    },
    {
      field: "title",
      headerName: "Title",
      type: "text",
      minWidth: widthTable.xs,
      maxWidth: widthTable.s,
      flex: 1,
      align: "left",
      headerAlign: "left",
    },
    {
      field: "description",
      headerName: "Description",
      type: "text",
      minWidth: widthTable.m,
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
  ];

  return (
    <Box className="banner-admin" sx={{ display: "flex" }}>
        <SideBar name="Banner" />
        <Toaster />
      <Box
        component="main"
        sx={{
          padding: 10,
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
              ...rows.initialState,
              pagination: { paginationModel: { pageSize: 5 } },

              sorting: {
                ...rows.initialState?.sorting,
                sortModel: [
                  {
                    field: 'isDisplayed',
                    sort: 'desc',
                  },
                ],
              },
            }}
            pageSizeOptions={[5, 10, 25]}
            slotProps={{
              toolbar: { setRows, setRowModesModel },
            }}
            {...rows}
            />
        </div>
      </Box>
      <div className={`edit-show ${isPopupVisible ? "active" : ""}`}>
        <EditBanner
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
        <Button
          color={btnValue.colorAdd}
          startIcon={<AddIcon />}
          onClick={handleAddClick}
          >
          Add record
        </Button>
        <GridToolbarQuickFilter />
      </GridToolbarContainer>
    );
  }
}
