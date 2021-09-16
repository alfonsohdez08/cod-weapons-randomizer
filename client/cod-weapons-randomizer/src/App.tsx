import React from "react";

import "bootstrap/dist/css/bootstrap.min.css";
import "./App.css";

import GenerateRandomLoadoutForm from "./components/GenerateRandomLoadoutForm";
import LoadoutContainer from "./components/LoadoutContainer";
import Header from "./components/Header";

import { Loadout } from "./api/models";

const App = () => {
  const [loadout, setLoadout] = React.useState<Loadout | undefined>();

  return (
    <div className="text-white d-flex flex-column">
      <Header />
      <div className="flex-grow-1 d-flex flex-column">
        <div className="w-75 mx-auto flex-grow-1">
          <GenerateRandomLoadoutForm onGenerateLoadout={setLoadout} />
          {loadout ? (
            <div className="mt-3 bg-dark border-2 rounded-3 shadow p-2 p-md-4">
              <LoadoutContainer loadout={loadout} />
            </div>
          ) : (
            <></>
          )}
        </div>
      </div>
    </div>
  );
};

export default App;
