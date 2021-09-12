import { Weapon, Attachment } from "../api/models";

import { Card, ListGroup } from "react-bootstrap";

const WeaponCard = ({ weapon }: { weapon: Weapon }) => {
  return (
    <Card as="div" bg="secondary" border="dark">
      <Card.Header>
        <div className="d-inline-block h4">{weapon.name}</div>
        <span className="ms-1 text-dark h6">({weapon.weaponType})</span>
      </Card.Header>
      {weapon.hasImage() ? (
        <Card.Img
          src={weapon.imageUrl}
          variant="top"
          className="weapon-image"
        />
      ) : (
        <></>
      )}
      {weapon.attachments && weapon.attachments.length > 0 ? (
        <WeaponAttachmentList attachments={weapon.attachments} />
      ) : (
        <></>
      )}
    </Card>
  );
};

const WeaponAttachmentList = ({
  attachments,
}: {
  attachments: Attachment[];
}) => (
  <>
    <ListGroup variant="flush">
      <ListGroup.Item variant="dark">
        <span className="h5">Attachments</span>
      </ListGroup.Item>
      {attachments.map((a, idx) => (
        <ListGroup.Item variant="secondary" key={idx}>
          <strong>{a.name}:</strong>
          <span className="ms-2">{a.variant.name}</span>
        </ListGroup.Item>
      ))}
    </ListGroup>
  </>
);

export default WeaponCard;
