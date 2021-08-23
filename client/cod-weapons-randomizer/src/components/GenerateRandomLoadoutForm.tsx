import LoadoutGenerationHints from "./LoadoutGenerationHints";
import Button from "./Button";

const GenerateRandomLoadoutForm = () => (
  <div>
    <LoadoutGenerationHints />
    <Button placeholder="Generate Loadout" type="submit" theme="secondary" />
  </div>
);

export default GenerateRandomLoadoutForm;
