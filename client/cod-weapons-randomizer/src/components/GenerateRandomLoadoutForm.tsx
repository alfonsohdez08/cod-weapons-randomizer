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
  const [enforceOverkillPerk, setEnforceOverkillPerk] = React.useState(false);
  const [enforceAllAttachments, setEnforceAllAttachments] =
    React.useState(false);

  const generateRandomLoadout = () => {
    API.generateRandomLoadout({
      enforceAllAttachmentSlots: enforceAllAttachments,
      enforceOverkillPerk: enforceOverkillPerk,
    }).then((loadout) => {
      console.log(loadout);
      onGenerateLoadout(loadout);
    });
  };

  return (
    <Form onSubmit={generateRandomLoadout}>
      <Container className="px-0">
        <Row className="row-cols-1 gy-2">
          <Col>
            <LoadoutGenerationHints
              enforceUseAllWeaponAttachments={enforceAllAttachments}
              onEnforceUseAllWeaponAttachmentsChange={setEnforceAllAttachments}
              enforceUseOverkillPerk={enforceOverkillPerk}
              onEnforceUseOverkillPerkChange={setEnforceOverkillPerk}
            />
          </Col>
          <Col>
            <div className="d-flex justify-content-center">
              <Button
                placeholder="Generate Loadout"
                type="submit"
                theme="secondary"
              />
            </div>
          </Col>
        </Row>
      </Container>
    </Form>
  );
};

export default GenerateRandomLoadoutForm;
