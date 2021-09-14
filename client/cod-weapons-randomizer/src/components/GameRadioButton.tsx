import { Form } from "react-bootstrap";
import { COD } from "../api/models";

export interface RadioProps {
  value: COD;
  onChange: (selectedGame: COD) => void;
  checked: boolean;
}

const GameRadioButton = ({ value, onChange, checked }: RadioProps) => (
  <Form.Check
    type="radio"
    value={value.toString()}
    className="d-inline-block"
    checked={checked}
    onChange={(e) => onChange(e.target.value as COD)}
  />
);

export default GameRadioButton;
