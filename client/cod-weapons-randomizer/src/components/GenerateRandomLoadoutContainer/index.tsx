import "./styles.css";

const GenerateRandomLoadoutContainer = () => (
  <div>
    <LoadoutHints />
    <Button />
  </div>
);

const Button = () => (
  <button className="btn">
    <span>Generate Loadout</span>
  </button>
);

const LoadoutHints = () => (
  <div>
    <Checkbox placeholder="Use all attachment slots" />
    <Checkbox placeholder="Use Overkill perk" />
  </div>
);

const Checkbox = ({ placeholder }: { placeholder: string }) => (
  <div>
    <input type="checkbox" />
    <label>{placeholder}</label>
  </div>
);

export default GenerateRandomLoadoutContainer;
