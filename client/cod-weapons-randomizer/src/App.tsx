import React from "react";

import "bootstrap/dist/css/bootstrap.min.css";
import "./App.css";

import GenerateRandomLoadoutForm from "./components/GenerateRandomLoadoutForm";
import LoadoutContainer from "./components/LoadoutContainer";

import { Loadout } from "./api/models";

const App = () => {
  const [loadout, setLoadout] = React.useState<Loadout | undefined>();

  return (
    <>
      <div className="w-75 mt-3 mx-auto">
        <GenerateRandomLoadoutForm onGenerateLoadout={setLoadout} />
        {loadout ? (
          <div className="mt-3">
            <LoadoutContainer loadout={loadout} />
          </div>
        ) : (
          <></>
        )}
      </div>
    </>
  );
};

export default App;
