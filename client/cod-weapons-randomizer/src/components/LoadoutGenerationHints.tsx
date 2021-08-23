import Checkbox from "./Checkbox";

export interface LoadoutGenerationHintsProps {
  enforceUseAllWeaponAttachments: boolean;
  onEnforceUseAllWeaponAttachmentsChange: (value: boolean) => void;
  enforceUseOverkillPerk: boolean;
  onEnforceUseOverkillPerkChange: (value: boolean) => void;
}

const LoadoutGenerationHints = ({
  enforceUseAllWeaponAttachments,
  onEnforceUseAllWeaponAttachmentsChange,
  enforceUseOverkillPerk,
  onEnforceUseOverkillPerkChange,
}: LoadoutGenerationHintsProps) => {
  const checkBoxes: JSX.Element[] = [
    <Checkbox
      label="Enforce use all weapon attachments"
      value={enforceUseAllWeaponAttachments}
      onChange={onEnforceUseAllWeaponAttachmentsChange}
    />,
    <Checkbox
      label="Enforce use Overkill perk"
      value={enforceUseOverkillPerk}
      onChange={onEnforceUseOverkillPerkChange}
    />,
  ];

  return (
    <>
      <div className="d-md-none ">
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
