import { Loadout } from "../api/models";

import WeaponCard from "./WeaponCard";

const LoadoutContainer = ({ loadout }: { loadout: Loadout }) => (
  <div>
    <WeaponCard weapon={loadout.primaryWeapon} weaponOrder="primary" />
  </div>
);

export default LoadoutContainer;
