import React from "react";
import Adapter from "enzyme-adapter-react-16";
import { configure, shallow } from "enzyme";
import StateTable from "../feature/stateTable";

configure({ adapter: new Adapter() });
test("renders the component", () => {
  const props = { columns: ([] = []), rows: ([] = []) };
  const component = shallow(<StateTable {...props} />);
  expect(component).toMatchSnapshot();
});
