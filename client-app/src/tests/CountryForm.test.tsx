import React from "react";
import Adapter from "enzyme-adapter-react-16";
import { configure, shallow } from "enzyme";
import CountryForm from "../feature/countryForm";

configure({ adapter: new Adapter() });
test("renders the component", () => {
  const component = shallow(<CountryForm />);
  expect(component).toMatchSnapshot();
});
