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
      placeholder="Use all attachment slots"
      value={useAllAttachments}
      onChange={onUseAllAttachmentsChange}
    />,
    <Checkbox
      placeholder="Use Overkill perk"
      value={enforceOverkillPerk}
      onChange={onEnforceOverkillPerkChange}
    />,
  ];

  return (
    <>
      <div className="d-sm-none border border-2 border-secondary rounded rounded-2 p-2">
        {checkBoxes.map((ch, idx) => (
          <div key={idx} className="d-block">
            {ch}
          </div>
        ))}
      </div>
      <div className="d-none d-sm-flex justify-content-center">
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
