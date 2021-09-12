import LoadoutGenerationHints from "./LoadoutGenerationHints";
import Button from "./Button";
import GameRadioButton, { COD } from "./GameRadioButton";

import React from "react";
import { Container, Row, Col } from "react-bootstrap";

import API from "../api";
import { Loadout } from "../api/models";

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
      <Container className="px-0">
        <Row className="row-cols-1 gy-2">
          <Col>
            <Row className="gy-0 gx-1 row-cols-auto align-items-center justify-content-center">
              <Col>
                <GameRadioButton
                  value={COD.ModernWarfare}
                  checked={cod === COD.ModernWarfare}
                  onChange={setCod}
                />
              </Col>
              <Col>
                <img
                  src="/mw_logo.png"
                  alt="COD MW 2019 Logo"
                  className="mw-logo"
                />
              </Col>
              <Col className="offset-1">
                <GameRadioButton
                  value={COD.Warzone}
                  checked={cod === COD.Warzone}
                  onChange={setCod}
                />
              </Col>
              <Col>
                <img
                  src="/wz_logo.png"
                  alt="COD MW 2019 Logo"
                  className="wz-logo"
                />
              </Col>
            </Row>
          </Col>
          <Col>
            <LoadoutGenerationHints
              enforceUseAllWeaponAttachmentSlots={
                enforceUseAllWeaponAttachmentSlots
              }
              onEnforceUseAllWeaponAttachmentSlotsChange={
                setEnforceUseAllWeaponAttachmentSlots
              }
              enforceUseOverkillPerk={enforceUseOverkillPerk}
              onEnforceUseOverkillPerkChange={setEnforceUseOverkillPerk}
            />
          </Col>
          <Col>
            <div className="d-flex justify-content-center">
              <Button
                placeholder="Generate Loadout"
                type="submit"
                theme="dark"
              />
            </div>
          </Col>
        </Row>
      </Container>
    </Form>
  );
};

export default GenerateRandomLoadoutForm;
