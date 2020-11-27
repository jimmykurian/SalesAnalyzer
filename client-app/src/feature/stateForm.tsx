/* eslint-disable no-restricted-globals */

// React imports
import React, { useEffect, useState } from "react";
import "../app/layout/styles.css";

// Material UI imports
import Typography from "@material-ui/core/Typography/Typography";
import Grid from "@material-ui/core/Grid/Grid";
import TextField from "@material-ui/core/TextField/TextField";
import Autocomplete from "@material-ui/lab/Autocomplete/Autocomplete";

// 3rd Party Libraries
import { useForm } from "react-hook-form";
import axios from "axios";
import * as _ from "lodash";

// Models
import { IStateUSA } from "../app/models/statesUSA";
import { IStateRegion } from "../app/models/stateRegion";

interface Props {
  submissionHandler: () => void;
  selectedSubmission: string;
}

const StateForm = ({ submissionHandler, selectedSubmission }: Props) => {
  const [indexes, setIndexes] = useState([] as any);
  const [counter, setCounter] = useState(0);
  const [statesUSA, setStatesUSA] = useState<IStateUSA[]>([]);

  const { register, handleSubmit, errors } = useForm();

  function generateUUID(): string {
    // Public Domain/MIT
    let d = new Date().getTime(); // Timestamp
    let d2 = (performance && performance.now && performance.now() * 1000) || 0; // Time in microseconds since page-load or 0 if unsupported
    return "xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx".replace(
      /[xy]/g,
      function (c) {
        let r = Math.random() * 16; // random number between 0 and 16
        if (d > 0) {
          // Use timestamp until depleted
          r = (d + r) % 16 | 0;
          d = Math.floor(d / 16);
        } else {
          // Use microseconds since page-load if supported
          r = (d2 + r) % 16 | 0;
          d2 = Math.floor(d2 / 16);
        }
        return (c === "x" ? r : (r & 0x3) | 0x8).toString(16);
      }
    );
  }

  const onSubmit = (data: any) => {
    console.log(data);
    const stateRegions: IStateRegion[] = [];
    data.states.forEach((element: any, index: any) => {
      const stateRegion: IStateRegion = {
        id: generateUUID(),
        state: element.state,
        month: element.month,
        numberOfSales: parseInt(element.numberOfSales, 10),
      };
      stateRegions.push(stateRegion);
    });

    axios
      .post("http://localhost:5000/api/stateRegions", {
        stateRegions,
      })
      .then(
        (response) => {
          console.log(response);
          submissionHandler();
        },
        (error) => {
          console.log(error);
        }
      );
  };

  const addRecord = () => {
    setIndexes((prevIndexes: any) => [...prevIndexes, counter]);
    setCounter((prevCounter) => prevCounter + 1);
  };

  const removeRecord = (index: any) => () => {
    setIndexes((prevIndexes: any) => [
      ...prevIndexes.filter((item: any) => item !== index),
    ]);
    setCounter((prevCounter) => prevCounter - 1);
  };

  const clearRecords = () => {
    setIndexes([]);
  };

  const months = [
    { name: "January" },
    { name: "February" },
    { name: "March" },
    { name: "April" },
    { name: "May" },
    { name: "June" },
    { name: "July" },
    { name: "August" },
    { name: "September" },
    { name: "October" },
    { name: "November" },
    { name: "December" },
  ];

  useEffect(() => {
    axios
      .get<IStateUSA[]>("http://localhost:5000/api/states")
      .then((response) => {
        let sortedStates = response.data;
        sortedStates = _.orderBy(sortedStates, ["name"], ["asc"]);
        setStatesUSA(sortedStates);
      });
  }, []);

  return (
    <div>
      <div>
        <Grid container justify="center">
          <Typography variant="h6" style={{ color: "#FFFFFF" }} gutterBottom>
            States
          </Typography>
        </Grid>
      </div>
      <div>
        <form onSubmit={handleSubmit(onSubmit)}>
          {indexes.map((index: any) => {
            const fieldName = `states[${index}]`;
            return (
              <fieldset name={fieldName} key={fieldName}>
                <label>
                  State {index}:
                  <Autocomplete
                    id={`state-combo-box-${index}`}
                    options={statesUSA}
                    getOptionLabel={(option) => option.name}
                    style={{ width: "100%" }}
                    renderInput={(params) => (
                      <TextField
                        {...params}
                        required
                        id={`state-text-field-${index}`}
                        variant="filled"
                        color="secondary"
                        style={{ background: "#FFFFFF" }}
                        size="small"
                        name={`${fieldName}.state`}
                        inputRef={register({ required: true })}
                      />
                    )}
                  />
                </label>
                <label>
                  Month {index}:
                  <Autocomplete
                    id={`month-combo-box-${index}`}
                    options={months}
                    getOptionLabel={(option) => option.name}
                    style={{ width: "100%" }}
                    renderInput={(params) => (
                      <TextField
                        {...params}
                        required
                        id={`month-text-field-${index}`}
                        variant="filled"
                        color="secondary"
                        style={{ background: "#FFFFFF" }}
                        size="small"
                        name={`${fieldName}.month`}
                        inputRef={register({ required: true })}
                      />
                    )}
                  />
                </label>
                <label>
                  Number Of Sales {index}:
                  <TextField
                    required
                    id={`sales-text-field-${index}`}
                    variant="filled"
                    color="secondary"
                    type="number"
                    style={{ background: "#FFFFFF", width: "100%" }}
                    size="small"
                    name={`${fieldName}.numberOfSales`}
                    inputRef={register({ required: true, maxLength: 10 })}
                  />
                </label>
                {errors.fieldName && <p>This field is required</p>}
                <button type="button" onClick={removeRecord(index)}>
                  Remove
                </button>
              </fieldset>
            );
          })}

          <button type="button" onClick={addRecord}>
            Add A State Record
          </button>
          <button type="button" onClick={clearRecords}>
            Clear State Records
          </button>
          <input type="submit" />
        </form>
      </div>
    </div>
  );
};

export default StateForm;
