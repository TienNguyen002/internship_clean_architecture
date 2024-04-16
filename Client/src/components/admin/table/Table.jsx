import React, { useState, useEffect} from "react";
import Box from "@mui/material/Box";
import Button from "@mui/material/Button";
import AddIcon from "@mui/icons-material/Add";
import EditIcon from "@mui/icons-material/Edit";
import DeleteIcon from "@mui/icons-material/DeleteOutlined";
import { useDemoData } from "@mui/x-data-grid-generator";
import {
  DataGrid,
  GridToolbarContainer,
  GridActionsCellItem,
  GridRowEditStopReasons,
  GridToolbarQuickFilter
} from "@mui/x-data-grid";
import { getItemBySectionSlug, deleteItemById } from "../../../api/ItemApi";
import {
  numberLength,
  queryDefault,
  btnValue,
  deleteForm,
  slugName,
  widthTable,
} from "../../../enum/EnumApi";
import Swal from "sweetalert2";
import { convertDate } from "../../../common/functions";
import EditBlog from "../edit/EditBlog";
import EditNew from "../edit/EditNew";
import "./Table.css";

export default function Table(props) {
  const [rows, setRows] = useState([]);
  const [idEdit, setIdEdit] = useState();
  const [rowModesModel, setRowModesModel] = useState({});
  const [isPopupVisible, setIsPopupVisible] = useState(false);
  const { name } = props;
  const payload = {
    sectionSlug: name,
    pageSize: numberLength.max,
    pageNumber: queryDefault.pageNumberDefault,
  };

  //call api get data
  useEffect(() => {
    getItem();
    async function getItem() {
      const data = await getItemBySectionSlug(payload);
      if (data) {
        setRows(data.items);
      } else setRows([rows.id]);
    }
  }, [rows.id]);

  const { data } = useDemoData({
    dataSet: "Commodity",
  });
  const handleRowEditStop = (params, event) => {
    if (params.reason === GridRowEditStopReasons.rowFocusOut) {
      event.defaultMuiPrevented = true;
    }
  }

  const togglePopup = () => {
    setIsPopupVisible(true);
    document.body.classList.toggle("popup-open");
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
      width: widthTable.s,
      renderCell: (rows) => (<img src={rows.value}/>),
    },
    {
      field: "title",
      headerName: "Title",
      type: "text",
      width: widthTable.s,
      align: "left",
      headerAlign: "left",
    },
    {
      field: "shortDescription",
      headerName: "Short Description",
      type: "text",
      width: widthTable.l,
    },
    {
      field: "createdDate",
      headerName: "Created Date",
      type: "Date",
      width: widthTable.ss,
      renderCell: (rows) => convertDate(rows.value),
    },
    {
      field: "updatedDate",
      headerName: "Updated Date",
      type: "Date",
      width: widthTable.ss,
      renderCell: (rows) => convertDate(rows.value),
    },
    {
      field: "subTitle",
      headerName: "Author",
      type: "text",
      width: widthTable.ss,
      align: "left",
      headerAlign: "left",
      hide: true,
    },
    {
      field: "actions",
      type: "actions",
      headerName: "Actions",
      width: widthTable.ss,
      cellClassName: "actions",
      getActions,
    },
  ];

  return (
    <Box style={{ display: "flex" }}>
      <Box
        component="main"
        sx={{
          padding: 10,
          justifyContent: "center",
          height: "98vh",
          width: "100%",
          "& .actions": {
            color: "text.secondary",
          },
          "& .textPrimary": {
            color: "text.primary",
          },
          display: "table", tableLayout: "fixed"
        }}
      >
        <div className="data-grid-container">
        <DataGrid
          rowHeight={200}
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
            subTitle: name === slugName.blogs ? true : false,
          }}
          initialState={{
            ...data.initialState,
            pagination: { paginationModel: { pageSize: 5 } },
          }}
          pageSizeOptions={[5, 10, 25]}
          slotProps={{
            toolbar: { setRows, setRowModesModel },
          }}
        />
        </div>
      </Box>
      {name === slugName.blogs && (
        <div className={`edit-show ${isPopupVisible ? "active" : ""}`}>
          <EditBlog
            id={idEdit}
            setRows={setRows}
            setIsPopupVisible={setIsPopupVisible}
          />
        </div>
      )}
      {name === slugName.news && (
        <div className={`edit-show ${isPopupVisible ? "active" : ""}`}>
          <EditNew
            id={idEdit}
            setRows={setRows}
            setIsPopupVisible={setIsPopupVisible}
          />
        </div>
      )}
    </Box>
  );
  function HandleToolbar() {
    return (
      <GridToolbarContainer sx={{justifyContent: 'space-between'}}>
        <Button
          color={btnValue.colorAdd}
          startIcon={<AddIcon />}
          onClick={handleAddClick}
        >
          Add record
        </Button>
        <GridToolbarQuickFilter/>
      </GridToolbarContainer>
    );
  }
}
