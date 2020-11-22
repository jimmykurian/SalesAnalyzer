// React imports
import React, { Component } from "react";
import "./App.css";

// Material UI
import Typography from "@material-ui/core/Typography/Typography";
import AssessmentOutlined from "@material-ui/icons/AssessmentOutlined";

// 3rd-party libraries
import axios from "axios";

class App extends Component {
  state = {
    values: [],
  };

  componentDidMount() {
    axios.get("http://localhost:5000/api/values").then((response) => {
      console.log(response);
      this.setState({
        values: response.data,
      });
    });
  }

  render() {
    return (
      <div>
        <Typography variant="h4" gutterBottom>
          <AssessmentOutlined fontSize="large" />
          Sales Analyzer
        </Typography>
        <ul>
          {this.state.values.map((value: any) => (
            <li key={value.id}>{value.name}</li>
          ))}
        </ul>
      </div>
    );
  }
}

export default App;
