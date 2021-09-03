import { Form } from "react-bootstrap";

export interface CheckboxProps {
  label: string;
  value: boolean;
  onChange: (newValue: boolean) => void;
}

const Checkbox = ({ label, value, onChange }: CheckboxProps) => {
  return (
    <Form.Check
      label={label}
      value={Number(value)}
      className="d-inline-block"
      onChange={(e) => onChange(e.target.checked)}
    />
  );
};

export default Checkbox;
