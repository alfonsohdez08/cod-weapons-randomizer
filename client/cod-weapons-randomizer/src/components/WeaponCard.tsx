import { Weapon, Attachment } from "../api/models";

import { Card, ListGroup } from "react-bootstrap";

const WeaponCard = ({ weapon }: { weapon: Weapon }) => {
  console.log(weapon);
  return (
    <Card>
      <Card.Header>
        <div className="d-inline-block h4">{weapon.name}</div>
        <span className="ms-1 text-muted h6">({weapon.category})</span>
      </Card.Header>
      <Card.Img></Card.Img>
      {weapon.attachments ? (
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
          <strong>{a.attachmentCategory}:</strong>
          <span className="ms-2">{a.name}</span>
        </ListGroup.Item>
      ))}
    </ListGroup>
  </>
);

export default WeaponCard;
