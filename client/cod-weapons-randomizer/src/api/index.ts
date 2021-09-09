import { Loadout, LoadoutGenerationHints } from "./models";

const generateRandomLoadout = async (hints: LoadoutGenerationHints): Promise<Loadout> => {
  const requestHeaders: HeadersInit = new Headers();
  requestHeaders.set("Content-Type", "application/json");

  const requestInit: RequestInit = {
    method: "POST",
    body: JSON.stringify(hints),
    headers: requestHeaders,
  };

  const response = await fetch("https://localhost:5001/mw-loadouts", requestInit);
  const loadout: Loadout = await response.json();

  return loadout;
};

export default {
  generateRandomLoadout,
};
