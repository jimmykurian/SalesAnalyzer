/* eslint-disable prefer-const */

// React imports
import React from "react";

// Material UI imports
import { DataGrid, ColDef, RowData } from "@material-ui/data-grid";

// 3rd-party libraries
import _ from "lodash";

interface Props {
  columns: ColDef[];
  rows: RowData[];
}

const StateTable = ({ columns, rows }: Props) => {
  return (
    <div
      style={{
        background: "#FFFFFF",
        height: 400,
        width: "100%",
        maxWidth: 1200,
      }}
    >
      <DataGrid rows={rows} columns={columns} pageSize={15} />
    </div>
  );
};

export default StateTable;
