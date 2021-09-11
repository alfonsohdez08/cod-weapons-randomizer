import React from "react";
import { Form } from "react-bootstrap";

export enum CodGame {
  ModernWarfare = "mw",
  Warzone = "wz",
}

export interface RadioProps {
  label: React.ReactNode;
  value: CodGame;
  onChange: (selectedGame: CodGame) => void;
  checked: boolean;
}

const GameRadioButton = ({ label, value, onChange, checked }: RadioProps) => (
  <Form.Check
    type="radio"
    label={label}
    value={value.toString()}
    checked={checked}
    onChange={(e) => onChange(e.target.value as CodGame)}
  />
);

export default GameRadioButton;
