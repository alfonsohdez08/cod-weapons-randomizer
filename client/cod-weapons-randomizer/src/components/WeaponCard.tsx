import { Weapon } from "../api/models";

import { Card } from "react-bootstrap";

const WeaponCard = ({
  weapon,
  weaponOrder,
}: {
  weapon: Weapon;
  weaponOrder: "primary" | "secondary";
}) => {
  return (
    <Card>
      <Card.Header>
        {weaponOrder === "primary" ? "Primary Weapon" : "Secondary Weapon"}
      </Card.Header>
      <Card.Body>
          <Card.Title>{weapon.name}</Card.Title>
      </Card.Body>
    </Card>
  );
};

export default WeaponCard;
