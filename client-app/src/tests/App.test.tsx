import React from "react";
import Adapter from "enzyme-adapter-react-16";
import { configure, shallow } from "enzyme";
import App from "../app/layout/App";

configure({ adapter: new Adapter() });
test("renders the component", () => {
  const component = shallow(<App />);
  expect(component).toMatchSnapshot();
});
