import { Form } from "react-bootstrap";

import InputProps from "./InputProps";

const Checkbox = ({ placeholder, value, onChange }: InputProps) => {
  const checkBoxValue: string | number =
    typeof value === "boolean" ? Number(value) : value;

  return (
    <Form.Check
      label={placeholder}
      value={checkBoxValue}
      className="d-inline-block"
      onChange={(e) => onChange(e.currentTarget.checked)}
    />
  );
};

export default Checkbox;
