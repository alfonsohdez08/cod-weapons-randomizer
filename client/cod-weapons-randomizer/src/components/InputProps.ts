export default interface InputProps {
  placeholder: string;
  value: string | boolean | number;
  onChange: (value: any) => void;
}
