// React imports
import React, { useState, useEffect } from "react";

// Material UI
import Typography from "@material-ui/core/Typography/Typography";
import AssessmentOutlined from "@material-ui/icons/AssessmentOutlined";
import makeStyles from "@material-ui/core/styles/makeStyles";
import { Theme } from "@material-ui/core/styles/createMuiTheme";
import createStyles from "@material-ui/core/styles/createStyles";
import Button from "@material-ui/core/Button/Button";
import Popper from "@material-ui/core/Popper/Popper";
import Grow from "@material-ui/core/Grow/Grow";
import Paper from "@material-ui/core/Paper/Paper";
import ClickAwayListener from "@material-ui/core/ClickAwayListener/ClickAwayListener";
import MenuList from "@material-ui/core/MenuList/MenuList";
import MenuItem from "@material-ui/core/MenuItem/MenuItem";
import {
  DataGrid,
  ColDef,
  ValueGetterParams,
  RowData,
  ValueFormatterParams,
} from "@material-ui/data-grid";

// 3rd-party libraries
import axios from "axios";

// Models
import { IStateRegion } from "../models/stateRegion";

// Components
import StateForm from "../../feature/stateForm";
import CountryForm from "../../feature/countryForm";
import { IStateMonthMatrix } from "../models/stateMonthMatrix";
import _ from "lodash";

const useStyles = makeStyles((theme: Theme) =>
  createStyles({
    root: {
      display: "flex",
    },
    paper: {
      marginRight: theme.spacing(2),
    },
  })
);

const App = () => {
  const [stateRegions, setStateRegions] = useState<IStateMonthMatrix[]>([]);
  const [columnHeaders, setColumnHeaders] = useState<ColDef[]>([]);
  const [rows, setRows] = useState<RowData[]>([]);
  const [selectedSubmission, setSubmission] = useState("");
  let [flag, setFlag] = useState("");
  const classes = useStyles();
  const [open, setOpen] = React.useState(false);
  const anchorRef = React.useRef<HTMLButtonElement>(null);

  const updateStateSubmission = () => {
    setSubmission("states");
    setFlag("");
  };

  const handleToggle = () => {
    setOpen((prevOpen) => !prevOpen);
  };

  const handleClose = (event: React.MouseEvent<EventTarget>) => {
    if (
      anchorRef.current &&
      anchorRef.current.contains(event.target as HTMLElement)
    ) {
      return;
    }

    setOpen(false);
  };

  function handleListKeyDown(event: React.KeyboardEvent) {
    if (event.key === "Tab") {
      event.preventDefault();
      setOpen(false);
    }
  }

  // return focus to the button when we transitioned from !open -> open
  const prevOpen = React.useRef(open);
  React.useEffect(() => {
    if (prevOpen.current === true && open === false) {
      anchorRef.current!.focus();
    }

    prevOpen.current = open;
  }, [open]);

  function getColumnHeadersAndRows(stateMonthMatrix: IStateMonthMatrix[]) {
    const headers: ColDef[] = [];
    const stateRows: RowData[] = [];
    let formattedStateName: string = "";
    let janRow: RowData = {
      id: "January",
    };
    let febRow: RowData = {
      id: "February",
    };
    let marRow: RowData = {
      id: "March",
    };
    let aprRow: RowData = {
      id: "April",
    };
    let mayRow: RowData = {
      id: "May",
    };
    let junRow: RowData = {
      id: "June",
    };
    let julRow: RowData = {
      id: "July",
    };
    let augRow: RowData = {
      id: "August",
    };
    let sepRow: RowData = {
      id: "September",
    };
    let octRow: RowData = {
      id: "October",
    };
    let novRow: RowData = {
      id: "November",
    };
    let decRow: RowData = {
      id: "December",
    };
    let avrRow: RowData = {
      id: "Average",
    };
    let medRow: RowData = {
      id: "Median",
    };
    let totRow: RowData = {
      id: "Total",
    };
    debugger;
    const colDef: ColDef = {
      field: "id",
      headerName: " ",
    };
    headers.push(colDef);
    stateMonthMatrix.forEach((element: any, index: any) => {
      const colDef: ColDef = {
        field: _.camelCase(element.stateName),
        headerName: element.stateName,
        valueFormatter: (params: ValueFormatterParams) =>
          params.value === 0 ? "-" : params.value,
      };
      headers.push(colDef);

      janRow['fieldName'] = element.januarySales;
      formattedStateName = _.camelCase(element.stateName);
      janRow[formattedStateName] = janRow["fieldName"]; 
      delete janRow["fieldName"];  

      febRow['fieldName'] = element.februarySales;
      formattedStateName = _.camelCase(element.stateName);
      febRow[formattedStateName] = febRow["fieldName"]; 
      delete febRow["fieldName"];  

      marRow['fieldName'] = element.marchSales;
      formattedStateName = _.camelCase(element.stateName);
      marRow[formattedStateName] = marRow["fieldName"]; 
      delete febRow["fieldName"];  

      aprRow['fieldName'] = element.aprilSales;
      formattedStateName = _.camelCase(element.stateName);
      aprRow[formattedStateName] = aprRow["fieldName"]; 
      delete febRow["fieldName"];  

      mayRow['fieldName'] = element.juneSales;
      formattedStateName = _.camelCase(element.stateName);
      mayRow[formattedStateName] = mayRow["fieldName"]; 
      delete febRow["fieldName"];  

      junRow['fieldName'] = element.julySales;
      formattedStateName = _.camelCase(element.stateName);
      junRow[formattedStateName] = junRow["fieldName"]; 
      delete febRow["fieldName"];  

      julRow['fieldName'] = element.augustSales;
      formattedStateName = _.camelCase(element.stateName);
      julRow[formattedStateName] = julRow["fieldName"]; 
      delete febRow["fieldName"];  

      augRow['fieldName'] = element.septemberSales;
      formattedStateName = _.camelCase(element.stateName);
      augRow[formattedStateName] = augRow["fieldName"]; 
      delete febRow["fieldName"];  

      sepRow['fieldName'] = element.septemberSales;
      formattedStateName = _.camelCase(element.stateName);
      sepRow[formattedStateName] = sepRow["fieldName"]; 
      delete febRow["fieldName"];  

      octRow['fieldName'] = element.octoberSales;
      formattedStateName = _.camelCase(element.stateName);
      octRow[formattedStateName] = octRow["fieldName"]; 
      delete febRow["fieldName"];  

      novRow['fieldName'] = element.novemberSales;
      formattedStateName = _.camelCase(element.stateName);
      novRow[formattedStateName] = novRow["fieldName"]; 
      delete febRow["fieldName"];  

      decRow['fieldName'] = element.decemberSales;
      formattedStateName = _.camelCase(element.stateName);
      decRow[formattedStateName] = decRow["fieldName"]; 
      delete febRow["fieldName"];   
      
      avrRow['fieldName'] = element.averageSales;
      formattedStateName = _.camelCase(element.stateName);
      avrRow[formattedStateName] = avrRow["fieldName"]; 
      delete febRow["fieldName"]; 

      medRow['fieldName'] = element.averageSales;
      formattedStateName = _.camelCase(element.stateName);
      medRow[formattedStateName] = medRow["fieldName"]; 
      delete febRow["fieldName"]; 

      totRow['fieldName'] = element.totalSales;
      formattedStateName = _.camelCase(element.stateName);
      totRow[formattedStateName] = totRow["fieldName"]; 
      delete febRow["fieldName"]; 
    });
    stateRows.push(janRow, febRow, marRow, aprRow, mayRow, junRow, julRow, augRow, sepRow, octRow, novRow, decRow, avrRow, medRow, totRow)
    debugger;
    setColumnHeaders(headers);
    setRows(stateRows);
    console.log(headers);
    console.log(stateRows);
  }

  useEffect(() => {
    axios
      .get<IStateMonthMatrix[]>(
        "http://localhost:5000/api/stateRegions/getByMatrix"
      )
      .then((response) => {
        setStateRegions(response.data);
        getColumnHeadersAndRows(response.data);
      });
  }, []);

  return (
    <div>
      <Typography variant="h4" style={{ color: "#FFFFFF" }} gutterBottom>
        <AssessmentOutlined fontSize="large" />
        Sales Analyzer
      </Typography>
      <div className={classes.root}>
        <div>
          <Button
            ref={anchorRef}
            aria-controls={open ? "menu-list-grow" : undefined}
            aria-haspopup="true"
            variant="contained"
            color="primary"
            onClick={handleToggle}
          >
            Select Region
          </Button>
          <Popper
            open={open}
            anchorEl={anchorRef.current}
            role={undefined}
            transition
            disablePortal
          >
            {({ TransitionProps, placement }) => (
              <Grow
                {...TransitionProps}
                style={{
                  transformOrigin:
                    placement === "bottom" ? "center top" : "center bottom",
                }}
              >
                <Paper>
                  <ClickAwayListener onClickAway={handleClose}>
                    <MenuList
                      autoFocusItem={open}
                      id="menu-list-grow"
                      onKeyDown={handleListKeyDown}
                    >
                      <MenuItem
                        onClick={() => {
                          setFlag((flag = "state"));
                          handleClose;
                        }}
                      >
                        US States/Territories
                      </MenuItem>
                      <MenuItem
                        onClick={() => {
                          setFlag((flag = "countries"));
                          handleClose;
                        }}
                      >
                        Countries
                      </MenuItem>
                    </MenuList>
                  </ClickAwayListener>
                </Paper>
              </Grow>
            )}
          </Popper>
        </div>
      </div>
      <div>
        {flag === "state" ? (
          <StateForm
            submissionHandler={updateStateSubmission}
            selectedSubmission={selectedSubmission}
          />
        ) : flag === "countries" ? (
          <CountryForm />
        ) : (
          ""
        )}
      </div>
      <div>{selectedSubmission === "states" ? "STATES TEST" : ""}</div>
      <div style={{ background: "#FFFFFF", height: 400, width: "100%" , maxWidth: 1200}}>
        <DataGrid rows={rows} columns={columnHeaders} pageSize={15} />
      </div>
    </div>
  );
};

export default App;
