// React Imports
import React, { useEffect, useState, Fragment } from "react";
import "../app/layout/styles.css";

// Material UI imports
import Typography from "@material-ui/core/Typography/Typography";
import Grid from "@material-ui/core/Grid/Grid";
import TextField from "@material-ui/core/TextField/TextField";
import Autocomplete from "@material-ui/lab/Autocomplete/Autocomplete";

// 3rd Party Libraries
import { useForm } from "react-hook-form";
import { ErrorMessage } from "@hookform/error-message";
import axios from "axios";
import * as _ from "lodash";

// Models
import { ICountry } from "../app/models/country";

function CountryForm() {
  const [indexes, setIndexes] = useState([] as any);
  const [counter, setCounter] = useState(0);
  const [countries, setCountries] = useState<ICountry[]>([]);

  const { register, handleSubmit, errors } = useForm();

  const onSubmit = (data: any) => {
    console.log(data);
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

  useEffect(() => {
    axios
      .get<ICountry[]>("http://localhost:5000/api/countries")
      .then((response) => {
        let sortedCountries = response.data;
        sortedCountries = _.orderBy(sortedCountries, ["name"], ["asc"]);
        setCountries(sortedCountries);
      });
  }, []);

  return (
    <div>
      <div>
        <Grid container justify="center">
          <Typography variant="h6" style={{ color: "#FFFFFF" }} gutterBottom>
            Countries
          </Typography>
        </Grid>
      </div>
      <div>
        <form onSubmit={handleSubmit(onSubmit)}>
          {indexes.map((index: any) => {
            const fieldName = `countries[${index}]`;
            return (
              <fieldset name={fieldName} key={fieldName}>
                <label>
                  Country {index}:
                  <Autocomplete
                    id={`countries-combo-box-${index}`}
                    options={countries}
                    getOptionLabel={(option) => option.name}
                    style={{ width: "100%" }}
                    renderInput={(params) => (
                      <TextField
                        {...params}
                        required
                        id={`country-text-field-${index}`}
                        variant="filled"
                        color="secondary"
                        style={{ background: "#FFFFFF" }}
                        size="small"
                        name={`${fieldName}.countryName`}
                        inputRef={register({ required: true })}
                      />
                    )}
                  />
                </label>
                <label>
                  Year {index}:
                  <TextField
                    required
                    id={`year-input-field-${index}`}
                    variant="filled"
                    color="secondary"
                    type="number"
                    style={{ background: "#FFFFFF", width: "100%" }}
                    size="small"
                    name={`${fieldName}.year`}
                    inputRef={register({
                      required: true,
                      minLength: {
                        value: 4,
                        message: "Please enter a year in YYYY format",
                      },
                      maxLength: {
                        value: 4,
                        message: "Please enter a year in YYYY format",
                      },
                      min: {
                        value: 1900,
                        message: "Please enter a year between 1900 and 2100",
                      },
                      max: {
                        value: 2100,
                        message: "Please enter a year between 1900 and 2100",
                      },
                    })}
                  />
                  <ErrorMessage
                    errors={errors}
                    name={`${fieldName}.year`}
                    render={({ messages }) => {
                      console.log("messages", messages);
                      return messages
                        ? Object.entries(messages).map(([type, message]) => (
                            <p key={type}>{message}</p>
                          ))
                        : null;
                    }}
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
                <button type="button" onClick={removeRecord(index)}>
                  Remove
                </button>
              </fieldset>
            );
          })}
          <button type="button" onClick={addRecord}>
            Add A Country Record
          </button>
          <button type="button" onClick={clearRecords}>
            Clear Country Records
          </button>
          <input type="submit" />
        </form>
      </div>
    </div>
  );
}

export default CountryForm;
