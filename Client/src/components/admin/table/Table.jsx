import React, { useState, useEffect} from "react";
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
import { useSelector } from "react-redux";
import "./Table.css";

export default function Table(props) {
  const [rows, setRows] = useState([]);
  const [idEdit, setIdEdit] = useState();
  const [rowModesModel, setRowModesModel] = useState({});
  const [isPopupVisible, setIsPopupVisible] = useState(false);
  const { name } = props;
  const currentLanguage = useSelector(
    (state) => state.language.currentLanguage
  );
  const payload = {
    SectionSlug: name,
    Locale: currentLanguage,
    PageSize: numberLength.max,
    PageNumber: queryDefault.pageNumberDefault,
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
  }, [rows.id, currentLanguage] );

  const handleRowEditStop = (params, event) => {
    if (params.reason === GridRowEditStopReasons.rowFocusOut) {
      event.defaultMuiPrevented = true;
    }
  }

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
      minWidth: widthTable.s,
      maxWidth: widthTable.s,
      flex: 1,
      renderCell: (rows) => (<img className="imageUrl-table" src={rows.value}/>),
    },
    {
      field: "title",
      headerName: "Title",
      type: "text",
      minWidth: widthTable.s,
      maxWidth: widthTable.m,
      flex: 1,
      align: "left",
      headerAlign: "left",
    },
    {
      field: "shortDescription",
      headerName: "Short Description",
      type: "text",
      minWidth: widthTable.s,
      maxWidth: widthTable.xl,
      flex: 1
    },
    {
      field: "createdDate",
      headerName: "Created Date",
      type: "Date",
      renderCell: (rows) => convertDate(rows.value),
      minWidth: widthTable.xs,
      maxWidth: widthTable.s,
      flex: 1

    },
    {
      field: "updatedDate",
      headerName: "Updated Date",
      type: "Date",
      minWidth: widthTable.xs,
      maxWidth: widthTable.s,
      flex: 1,
      renderCell: (rows) => convertDate(rows.value),
    },
    {
      field: "subTitle",
      headerName: "Author",
      type: "text",
      align: "left",
      headerAlign: "left",
      hide: true,
      minWidth: widthTable.xs,
      maxWidth: widthTable.s,
      flex: 1
    },
    {
      field: "actions",
      type: "actions",
      headerName: "Actions",
      cellClassName: "actions",
      getActions,
      minWidth: widthTable.ss,
      maxWidth: widthTable.s,
      flex: 1
    },
  ];

  return (
    <Box sx={{ display: "flex" }}>
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
          display: "table", tableLayout: "fixed"
        }}
      >
        <div className="data-grid-container">
        <DataGrid
          getRowHeight={() => 'auto'}
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
            ...rows.initialState,
            pagination: { paginationModel: { pageSize: 5 } },
            sorting: {
              ...rows.initialState?.sorting,
              sortModel: [
                {
                  field: 'createdDate',
                  sort: 'desc',
                },
              ],
            },
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