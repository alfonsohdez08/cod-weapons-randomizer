import React from "react";

import "bootstrap/dist/css/bootstrap.min.css";
import "./App.css";

import GenerateRandomLoadoutForm from "./components/GenerateRandomLoadoutForm";
import WeaponCard from "./components/WeaponCard";

import { Loadout } from "./api/models";

const App = () => {
  const [loadout, setLoadout] = React.useState<Loadout | undefined>();

  return (
    <>
      <div className="w-75 mt-3 mx-auto">
        <GenerateRandomLoadoutForm onGenerateLoadout={setLoadout} />
        {loadout ? <LoadoutContainer loadout={loadout} /> : <></>}
      </div>
    </>
  );
};

const LoadoutContainer = ({ loadout }: { loadout: Loadout }) => (
  <div>
    {/* <WeaponCard weapon={loadout.primaryWeapon} weaponOrder="primary" /> */}
  </div>
);

export default App;
