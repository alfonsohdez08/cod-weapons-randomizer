import Checkbox from "./Checkbox";

export interface LoadoutGenerationHintsProps {
  enforceUseAllWeaponAttachmentSlots: boolean;
  onEnforceUseAllWeaponAttachmentSlotsChange: (value: boolean) => void;
  enforceUseOverkillPerk: boolean;
  onEnforceUseOverkillPerkChange: (value: boolean) => void;
}

const LoadoutGenerationHints = ({
  enforceUseAllWeaponAttachmentSlots,
  onEnforceUseAllWeaponAttachmentSlotsChange,
  enforceUseOverkillPerk,
  onEnforceUseOverkillPerkChange,
}: LoadoutGenerationHintsProps) => {
  const checkBoxes: JSX.Element[] = [
    <Checkbox
      label="Enforce use all weapon attachment slots"
      value={enforceUseAllWeaponAttachmentSlots}
      onChange={onEnforceUseAllWeaponAttachmentSlotsChange}
    />,
    <Checkbox
      label="Enforce use Overkill perk"
      value={enforceUseOverkillPerk}
      onChange={onEnforceUseOverkillPerkChange}
    />,
  ];

  return (
    <>
      <div className="text-center">
        <span className="h3">Hints</span>
      </div>
      <div className="d-md-none">
        {checkBoxes.map((ch, idx) => (
          <div key={idx} className="d-block">
            {ch}
          </div>
        ))}
      </div>
      <div className="d-none d-md-flex justify-content-center">
        {checkBoxes.map((ch, idx) => (
          <span key={idx} className={idx < checkBoxes.length - 1 ? "me-3" : ""}>
            {ch}
          </span>
        ))}
      </div>
    </>
  );
};

export default LoadoutGenerationHints;
