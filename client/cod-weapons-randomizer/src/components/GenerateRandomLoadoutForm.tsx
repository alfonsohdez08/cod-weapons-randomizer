import React from "react";

import LoadoutGenerationHints from "./LoadoutGenerationHints";
import Button from "./Button";
import GameRadioButton from "./GameRadioButton";

import API from "../api";
import { Loadout, COD } from "../api/models";

import "./styles.css";

const Form = ({
  onSubmit,
  children,
}: {
  onSubmit: () => void;
  children: React.ReactNode;
}) => (
  <form
    onSubmit={(e) => {
      e.preventDefault();
      onSubmit();
    }}
  >
    {children}
  </form>
);

const GenerateRandomLoadoutForm = ({
  onGenerateLoadout,
}: {
  onGenerateLoadout: (loadout: Loadout) => void;
}) => {
  const [enforceUseOverkillPerk, setEnforceUseOverkillPerk] =
    React.useState(false);
  const [
    enforceUseAllWeaponAttachmentSlots,
    setEnforceUseAllWeaponAttachmentSlots,
  ] = React.useState(false);
  const [cod, setCod] = React.useState(COD.ModernWarfare);

  const generateRandomLoadout = () => {
    API.generateRandomLoadout(cod, {
      enforceUseAllWeaponAttachmentSlots,
      enforceUseOverkillPerk,
    }).then((loadout) => {
      onGenerateLoadout(loadout);
    });
  };

  return (
    <Form onSubmit={generateRandomLoadout}>
      <div className="d-flex align-items-center justify-content-center gap-3">
        <div className="d-flex gap-1 align-items-center">
          <GameRadioButton
            value={COD.ModernWarfare}
            checked={cod === COD.ModernWarfare}
            onChange={setCod}
          />
          <img src="/mw_logo.png" alt="COD MW 2019 Logo" className="mw-logo" />
        </div>
        <div className="d-flex align-items-center">
          <GameRadioButton
            value={COD.Warzone}
            checked={cod === COD.Warzone}
            onChange={setCod}
          />
          <img src="/wz_logo.png" alt="COD MW 2019 Logo" className="wz-logo" />
        </div>
      </div>
      <LoadoutGenerationHints
        enforceUseAllWeaponAttachmentSlots={enforceUseAllWeaponAttachmentSlots}
        onEnforceUseAllWeaponAttachmentSlotsChange={
          setEnforceUseAllWeaponAttachmentSlots
        }
        enforceUseOverkillPerk={enforceUseOverkillPerk}
        onEnforceUseOverkillPerkChange={setEnforceUseOverkillPerk}
      />
      <div className="d-flex justify-content-center">
        <Button placeholder="Generate Loadout" type="submit" theme="dark" />
      </div>
    </Form>
  );
};

export default GenerateRandomLoadoutForm;
