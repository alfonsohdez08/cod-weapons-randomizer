import { Loadout } from "../api/models";

import WeaponCard from "./WeaponCard";

const LoadoutContainer = ({ loadout }: { loadout: Loadout }) => {
  const cards: JSX.Element[] = [<WeaponCard weapon={loadout.primaryWeapon} />];

  return (
    <>
      <div className="d-md-none">{cards}</div>
      <div className="d-none d-md-block">
        {cards.map((c) => (
          <div className="w-50">{c}</div>
        ))}
      </div>
    </>
  );
};

export default LoadoutContainer;
