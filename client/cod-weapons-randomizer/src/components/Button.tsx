import React from "react";
import { Button as BootstrapButton } from "react-bootstrap";

export interface ButtonProps {
  placeholder: string | React.ReactNode;
  disabled?: boolean;
  type: "submit" | "button";
  theme: "primary" | "secondary" | "warning";
  className?: string;
}

const Button = ({ placeholder, disabled, type, theme, className }: ButtonProps) => (
  <BootstrapButton type={type} disabled={disabled} variant={theme} className={className}>
    {placeholder}
  </BootstrapButton>
);

export default Button;
