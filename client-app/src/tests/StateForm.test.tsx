import React from "react";
import Adapter from "enzyme-adapter-react-16";
import { configure, shallow } from "enzyme";
import StateForm from "../feature/stateForm";

configure({ adapter: new Adapter() });
test("renders the component", () => {
  const props = {
    submissionHandler: () => null,
    selectedSubmission: Math.random().toString(36).substring(7),
  };
  const component = shallow(<StateForm {...props} />);
  expect(component).toMatchSnapshot();
});
