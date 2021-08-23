import LoadoutGenerationHints from "./LoadoutGenerationHints";
import Button from "./Button";

import React from "react";
import { Container, Row, Col } from "react-bootstrap";

import API from "../api";
import { Loadout } from "../api/models";

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
    <form
      onSubmit={(e) => {
        e.preventDefault();
        generateRandomLoadout();
      }}
    >
      <Container className="px-0">
        <Row className="row-cols-1 gy-2">
          <Col>
            <LoadoutGenerationHints
              useAllAttachments={enforceAllAttachments}
              onUseAllAttachmentsChange={setEnforceAllAttachments}
              enforceOverkillPerk={enforceOverkillPerk}
              onEnforceOverkillPerkChange={setEnforceOverkillPerk}
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
    </form>
  );
};

export default GenerateRandomLoadoutForm;
