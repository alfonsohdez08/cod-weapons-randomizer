import { Col, Container, Row } from "react-bootstrap";
import { IdName, Loadout } from "../api/models";

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
          <Row className="row-cols-1 row-cols-md-2 row-cols-xl-1 gy-2">
            <Col>
              <Row className="row-cols-1">
                <Col>
                  <LoadoutHeading placeholder="Perks" />
                </Col>
                <Col>
                  <PerkList perks={loadout.perks} />
                </Col>
              </Row>
            </Col>
            <Col>
              <Row className="row-cols-1 gy-2">
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

const PerkList = ({ perks }: { perks: IdName[] }) => {
  const data = perks.map((p, i) => ({
    id: `${p.id}_${p.name}`,
    perk: p.name,
    tier: `Tier ${i + 1}`,
  }));

  return (
    <>
      <ul className="list-unstyled d-xl-none mb-0">
        {data.map((d) => (
          <li key={d.id}>
            <span className="fw-bold">{d.tier}:</span> {d.perk}
          </li>
        ))}
      </ul>
      <ul className="d-none d-xl-block list-inline mb-0">
        {data.map((d) => (
          <li key={d.id} className="list-inline-item">
            <div className="d-inline-flex flex-column">
              <span className="fw-bold d-block text-center">{d.tier}</span>
              <span className="d-block">{d.perk}</span>
            </div>
          </li>
        ))}
      </ul>
    </>
  );
};

export default LoadoutContainer;
