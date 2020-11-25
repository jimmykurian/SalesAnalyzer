// React Imports
import React from "react";
import { useForm } from "react-hook-form";
import "../app/layout/styles.css";

// Material UI imports
import Typography from "@material-ui/core/Typography/Typography";
import Grid from "@material-ui/core/Grid/Grid";

function CountryForm() {
  const [indexes, setIndexes] = React.useState([] as any);
  const [counter, setCounter] = React.useState(0);
  const { register, handleSubmit } = useForm();

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

  return (
    <div>
      <Grid container justify="center">
        <Typography variant="h6" style={{ color: "#FFFFFF" }} gutterBottom>
          Countries
        </Typography>
      </Grid>
      <div>
        <form onSubmit={handleSubmit(onSubmit)}>
          {indexes.map((index: any) => {
            const fieldName = `friends[${index}]`;
            return (
              <fieldset name={fieldName} key={fieldName}>
                <label>
                  Country Name {index}:
                  <input
                    type="text"
                    name={`${fieldName}.firstName`}
                    ref={register}
                  />
                </label>

                <label>
                  Year {index}:
                  <input
                    type="text"
                    name={`${fieldName}.lastName`}
                    ref={register}
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
