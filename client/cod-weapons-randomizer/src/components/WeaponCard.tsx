import { Weapon, Attachment } from "../api/models";

import { Card } from "react-bootstrap";

const WeaponCard = ({
  weapon,
  weaponOrder,
}: {
  weapon: Weapon;
  weaponOrder: "primary" | "secondary";
}) => {
  console.log(weapon);
  return (
    <Card>
      <Card.Header>
        <span className="h4">
          {weaponOrder === "primary" ? "Primary Weapon" : "Secondary Weapon"}
        </span>
      </Card.Header>
      <Card.Body>
        <div className="card-title">
          <span className="h4">{weapon.name}</span>
          <span className="ms-1 text-muted">({weapon.category})</span>
        </div>
        <Card.Text className="mt-1">
          {weapon.attachments ? (
            <WeaponAttachments attachments={weapon.attachments} />
          ) : (
            <></>
          )}
        </Card.Text>
      </Card.Body>
    </Card>
  );
};

const WeaponAttachments = ({ attachments }: { attachments: Attachment[] }) => (
  <>
    <div className="h5">Attachments</div>
    {attachments.map((a, idx) => (
      <div key={idx}>
        <span className={"d-block " + (idx > 0 ? "mt-1" : "")}>
          <strong>{a.attachmentCategory}</strong>
        </span>
        <span className="mt-1">{a.name}</span>
      </div>
    ))}
  </>
);

export default WeaponCard;
