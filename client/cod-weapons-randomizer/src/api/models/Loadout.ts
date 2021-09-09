import IdName from "./IdName";
import Weapon from "./Weapon";

export default interface Loadout {
    primaryWeapon: Weapon;
    secondaryWeapon: Weapon;
    perks: IdName[];
    tactical: IdName;
    lethal: IdName;
}