import Attachment from "./Attachment";
import IdName from "./IdName";

export default interface Weapon extends IdName {
  weaponType: string;
  attachments: Attachment[];
  imageUrl: string;
}
