import React, { useEffect, useState } from "react";
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
import { deleteItemById } from "../../../api/ItemApi";
import {
  btnValue,
  deleteForm,
  sectionName,
  widthTable,
} from "../../../enum/EnumApi";
import Swal from "sweetalert2";
import SideBar from "../../../components/admin/sideBar/SideBar";
import EditSectionItem from "../../../components/admin/edit/EditSectionItem";
import "../../../components/admin/table/Table.css"
import { useSelector } from "react-redux";

export default function SectionItem(props) {
  const { name, slug, items } = props;
  const [rows, setRows] = useState(items);
  const [idEdit, setIdEdit] = useState();
  const [rowModesModel, setRowModesModel] = useState({});
  const [isPopupVisible, setIsPopupVisible] = useState(false);

  const handleRowEditStop = (params, event) => {
    if (params.reason === GridRowEditStopReasons.rowFocusOut) {
      event.defaultMuiPrevented = true;
    }
  };

  const currentLanguage = useSelector(
    (state) => state.language.currentLanguage
  );

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

  useEffect(() => {
    setRows(items);
  },[rows]);

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
      field: "imageUrl",
      headerName: "Image",
      minWidth: widthTable.m,
      maxWidth: widthTable.l,
      flex: 1,
      renderCell: (rows) => <img className="imageUrl-table" src={rows.value} />,
    },
    {
      field: "title",
      headerName: "Title",
      type: "text",
      minWidth: widthTable.m,
      maxWidth: widthTable.m,
      flex: 1,
      align: "left",
      headerAlign: "left",
    },
    {
      field: "subTitle",
      headerName: "Role",
      type: "text",
      minWidth: widthTable.l,
      maxWidth: widthTable.m,
      flex: 1,
      align: "left",
      headerAlign: "left",
      hide: true,
    },
    {
      field: "description",
      headerName: "Description",
      type: "text",
      minWidth: widthTable.s,
      maxWidth: widthTable.xl,
      renderCell: (params) => (
        <div
          dangerouslySetInnerHTML={{
            __html: params.value,
          }}
        />
      ),
      flex: 1,
    },
    {
      field: "buttonLabel",
      headerName: "Button Label",
      type: "text",
      align: "left",
      headerAlign: "left",
      hide: true,
      minWidth: widthTable.s,
      maxWidth: widthTable.s,
      flex: 1,
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
    <Box sx={{ display: "flex" }}>
      <SideBar name={`${name} Items`} />
      <Box
        component="main"
        sx={{
          padding: 10,
          height: "fit-content",
          width: "92%",
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
            columnVisibilityModel={{
              buttonLabel: name === sectionName.LastestJobs ? true : false,
              subTitle: name === sectionName.Customer ? true : false
            }}
            initialState={{
              ...rows.initialState,
              pagination: { paginationModel: { pageSize: 5 } },
            }}
            pageSizeOptions={[5, 10, 25]}
            slotProps={{
              toolbar: { setRows, setRowModesModel },
            }}
          />
        </div>
      </Box>
      <div className={`edit-show ${isPopupVisible ? "active" : ""}`}>
          <EditSectionItem
            id={idEdit}
            sectionSlug={slug}
            setRows={setRows}
            setIsPopupVisible={setIsPopupVisible}
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
