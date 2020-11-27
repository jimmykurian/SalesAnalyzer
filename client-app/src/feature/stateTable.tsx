// React imports
import React, { useEffect, useState } from "react";
import "../app/layout/styles.css";

// 3rd-party libraries
import axios from "axios";

// Models
import { IStateRegion } from "../app/models/stateRegion";

const stateTable = () => {
    const [stateRegions, setStateRegions] = useState<IStateRegion[]>([]);
    
    useEffect(() => {
        axios
          .get<IStateRegion[]>("http://localhost:5000/api/stateRegions")
          .then((response) => {
            setStateRegions(response.data);
          });
      }, []);
    
}