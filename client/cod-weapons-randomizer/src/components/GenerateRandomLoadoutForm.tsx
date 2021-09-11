import LoadoutGenerationHints from "./LoadoutGenerationHints";
import Button from "./Button";

import React from "react";
import { Container, Row, Col } from "react-bootstrap";

import API from "../api";
import { Loadout } from "../api/models";

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

  const generateRandomLoadout = () => {
    API.generateRandomLoadout({
      enforceUseAllWeaponAttachmentSlots,
      enforceUseOverkillPerk: enforceUseOverkillPerk,
    }).then((loadout) => {
      onGenerateLoadout(loadout);
    });
  };

  return (
    <Form onSubmit={generateRandomLoadout}>
      <Container className="px-0">
        <Row className="row-cols-1 gy-2">
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
                theme="danger"
              />
            </div>
          </Col>
        </Row>
      </Container>
    </Form>
  );
};

export default GenerateRandomLoadoutForm;
