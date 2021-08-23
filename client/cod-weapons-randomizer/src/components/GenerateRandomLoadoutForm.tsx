import LoadoutGenerationHints from "./LoadoutGenerationHints";
import Button from "./Button";

import { Container, Row, Col } from "react-bootstrap";

const GenerateRandomLoadoutForm = () => (
  <Container className="px-0">
    <Row className="row-cols-1 gy-2">
      <Col>
        <LoadoutGenerationHints />
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
);

export default GenerateRandomLoadoutForm;
