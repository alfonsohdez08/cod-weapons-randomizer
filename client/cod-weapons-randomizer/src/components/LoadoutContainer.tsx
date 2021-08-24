import { Loadout } from "../api/models";

import WeaponCard from "./WeaponCard";

const LoadoutContainer = ({ loadout }: { loadout: Loadout }) => (
  <div>
    <WeaponCard weapon={loadout.primaryWeapon} />
  </div>
);

export default LoadoutContainer;
