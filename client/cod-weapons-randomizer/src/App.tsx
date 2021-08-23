import React from "react";

import "bootstrap/dist/css/bootstrap.min.css";
import "./App.css";

import GenerateRandomLoadoutForm from "./components/GenerateRandomLoadoutForm";

const App = () => (
  <>
    <div className="w-75 mt-3 mx-auto">
      <GenerateRandomLoadoutForm />
    </div>
  </>
);

export default App;
