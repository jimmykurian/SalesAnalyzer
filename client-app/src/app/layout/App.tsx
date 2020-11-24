// React imports
import React, { useState, useEffect } from "react";

// Material UI
import Typography from "@material-ui/core/Typography/Typography";
import AssessmentOutlined from "@material-ui/icons/AssessmentOutlined";

// 3rd-party libraries
import axios from "axios";

// Models
import { IStateRegion } from "../models/stateRegion";

const App = () => {
  const [stateRegions, setStateRegions] = useState<IStateRegion[]>([]);

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
    </div>
  );
};

export default App;
