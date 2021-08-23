import Perk from "./Perk";
import Weapon from "./Weapon";

export default interface Loadout {
    primaryWeapon: Weapon;
    secondaryWeapon: Weapon;
    perks: Perk[];
    tactical: string;
    lethal: string;
}