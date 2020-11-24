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

// 3rd-party libraries
import axios from "axios";

// Models
import { IStateRegion } from "../models/stateRegion";

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
  const [stateRegions, setStateRegions] = useState<IStateRegion[]>([]);
  const classes = useStyles();
  const [open, setOpen] = React.useState(false);
  const anchorRef = React.useRef<HTMLButtonElement>(null);

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

  useEffect(() => {
    axios
      .get<IStateRegion[]>("http://localhost:5000/api/stateRegions")
      .then((response) => {
        setStateRegions(response.data);
      });
  }, []);

  return (
    <div>
      <Typography variant="h4" gutterBottom>
        <AssessmentOutlined fontSize="large" />
        Sales Analyzer
      </Typography>
      <ul>
        {stateRegions.map((stateRegion) => (
          <li key={stateRegion.id}>
            {stateRegion.state}, {stateRegion.month},{" "}
            {stateRegion.numberOfSales}
          </li>
        ))}
      </ul>
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
                      <MenuItem onClick={handleClose}>US States/Territories</MenuItem>
                      <MenuItem onClick={handleClose}>Countries</MenuItem>
                    </MenuList>
                  </ClickAwayListener>
                </Paper>
              </Grow>
            )}
          </Popper>
        </div>
      </div>
    </div>
  );
};

export default App;
