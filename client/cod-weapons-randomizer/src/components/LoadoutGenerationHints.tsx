import Checkbox from "./Checkbox";

const LoadoutGenerationHints = () => (
  <div className="border border-2 border-secondary rounded rounded-2 p-2">
    <Checkbox placeholder="Use all attachment slots" value={false} />
    <Checkbox placeholder="Use Overkill perk" value={false} />
  </div>
);

export default LoadoutGenerationHints;
