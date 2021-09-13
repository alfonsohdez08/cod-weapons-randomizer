import { COD } from "../components/GameRadioButton";
import { Loadout, LoadoutGenerationHints } from "./models";
import Weapon from "./models/Weapon"; // this is a hack

const baseUrl = "https://localhost:5001";

const CODUrls = {
  [COD.ModernWarfare]: "mw-loadouts",
  [COD.Warzone]: "wz-loadouts",
};

const generateRandomLoadout = async (
  cod: COD,
  hints: LoadoutGenerationHints
): Promise<Loadout> => {
  const requestHeaders: HeadersInit = new Headers();
  requestHeaders.set("Content-Type", "application/json");

  const requestInit: RequestInit = {
    method: "POST",
    body: JSON.stringify(hints),
    headers: requestHeaders,
  };

  const response = await fetch(`${baseUrl}/${CODUrls[cod]}`, requestInit);
  const loadout: Loadout = await response.json();

  setLoadoutWeaponImageUrls(loadout);

  return loadout;
};

const setLoadoutWeaponImageUrls = (loadout: Loadout): void => {
  loadout.primaryWeapon = Weapon.clone(loadout.primaryWeapon);
  loadout.secondaryWeapon = Weapon.clone(loadout.secondaryWeapon);

  loadout.primaryWeapon.setWeaponImageUrl(baseUrl);
  loadout.secondaryWeapon.setWeaponImageUrl(baseUrl);
};

export default {
  generateRandomLoadout,
};
