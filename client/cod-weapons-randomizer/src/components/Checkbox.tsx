import { Form } from "react-bootstrap";

import InputProps from "./InputProps";

const Checkbox = ({ placeholder, value }: InputProps) => {
  const checkBoxValue: string | number =
    typeof value === "boolean" ? Number(value) : value;

  return <Form.Check label={placeholder} value={checkBoxValue} />;
};

export default Checkbox;
