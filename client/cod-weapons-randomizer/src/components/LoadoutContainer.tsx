import { Col, Container, Row } from "react-bootstrap";
import { Loadout } from "../api/models";

import WeaponCard from "./WeaponCard";

const LoadoutContainer = ({ loadout }: { loadout: Loadout }) => {
  return (
    <Container>
      <Row className="row-cols-1 row-cols-xl-2 gy-2 gy-xl-0 gx-xl-5">
        <Col>
          <Row className="row-cols-1">
            <Col>
              <LoadoutHeading placeholder="Weapons" />
            </Col>
            <Col>
              <Row className="row-cols-1 row-cols-md-2 gy-2 gy-md-0 gx-md-3">
                <Col>
                  <WeaponCard weapon={loadout.primaryWeapon} />
                </Col>
                <Col>
                  <WeaponCard weapon={loadout.secondaryWeapon} />
                </Col>
              </Row>
            </Col>
          </Row>
        </Col>
        <Col>
          <Row className="row-cols-1 row-cols-md-2 row-cols-xl-1 gy-xl-2">
            <Col>
              <Row className="row-cols-1">
                <Col>
                  <LoadoutHeading placeholder="Perks" />
                </Col>
                <Col>
                  <List
                    items={loadout.perks.map((p) => ({
                      id: p.id,
                      label: p.name,
                    }))}
                  />
                </Col>
              </Row>
            </Col>
            <Col>
              <Row className="row-cols-1">
                <Col>
                  <Row className="row-cols-1">
                    <Col>
                      <LoadoutHeading placeholder="Tactical" />
                    </Col>
                    <Col>
                      <span>{loadout.tactical.name}</span>
                    </Col>
                  </Row>
                </Col>
                <Col>
                  <Row className="row-cols-1">
                    <Col>
                      <LoadoutHeading placeholder="Lethal" />
                    </Col>
                    <Col>
                      <span>{loadout.lethal.name}</span>
                    </Col>
                  </Row>
                </Col>
              </Row>
            </Col>
          </Row>
        </Col>
      </Row>
    </Container>
  );
};

const LoadoutHeading = ({ placeholder }: { placeholder: string }) => (
  <h3 className="d-inline-block">{placeholder}</h3>
);

const List = ({ items }: { items: { id: number; label: string }[] }) => {
  return (
    <>
      <ul className="list-unstyled d-xl-none mb-0">
        {items.map((i) => (
          <li key={`${i.id}_${i.label}`}>{i.label}</li>
        ))}
      </ul>
      <ul className="d-none d-xl-block list-inline mb-0">
        {items.map((i) => (
          <li key={`${i.id}_${i.label}`} className="list-inline-item">
            {i.label}
          </li>
        ))}
      </ul>
    </>
  );
};

export default LoadoutContainer;
