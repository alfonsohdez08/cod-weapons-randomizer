import Checkbox from "./Checkbox";

export interface LoadoutGenerationHintsProps {
  useAllAttachments: boolean;
  onUseAllAttachmentsChange: (value: boolean) => void;
  enforceOverkillPerk: boolean;
  onEnforceOverkillPerkChange: (value: boolean) => void;
}

const LoadoutGenerationHints = ({
  useAllAttachments,
  onUseAllAttachmentsChange,
  enforceOverkillPerk,
  onEnforceOverkillPerkChange,
}: LoadoutGenerationHintsProps) => {
  const checkBoxes: JSX.Element[] = [
    <Checkbox
      placeholder="Enforce use all weapon attachments"
      value={useAllAttachments}
      onChange={onUseAllAttachmentsChange}
    />,
    <Checkbox
      placeholder="Enforce use Overkill perk"
      value={enforceOverkillPerk}
      onChange={onEnforceOverkillPerkChange}
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
