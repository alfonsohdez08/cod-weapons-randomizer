import Attachment from "./Attachment";
import IdName from "./IdName";

export default class Weapon implements IdName {
  id: number;
  name: string;
  weaponType: string;
  attachments: Attachment[];
  imageUrl!: string;
  private imageServerPath: string;

  constructor(
    id: number,
    name: string,
    weaponType: string,
    attachments: Attachment[],
    imageServerPath: string
  ) {
    this.id = id;
    this.name = name;
    this.weaponType = weaponType;
    this.attachments = attachments;
    this.imageServerPath = imageServerPath;
  }

  public setWeaponImageUrl(serverBaseUrl: string): void {
    this.imageUrl = `${serverBaseUrl}/${this.imageServerPath}`;
  }

  public static clone(weapon: Weapon): Weapon {
    return new Weapon(
      weapon.id,
      weapon.name,
      weapon.weaponType,
      weapon.attachments,
      weapon.imageServerPath
    );
  }
}
