import { Loadout, LoadoutGenerationHints, Weapon } from "./models";

const baseUrl = "https://localhost:5001";

const generateRandomLoadout = async (
  hints: LoadoutGenerationHints
): Promise<Loadout> => {
  const requestHeaders: HeadersInit = new Headers();
  requestHeaders.set("Content-Type", "application/json");

  const requestInit: RequestInit = {
    method: "POST",
    body: JSON.stringify(hints),
    headers: requestHeaders,
  };

  const response = await fetch(`${baseUrl}/mw-loadouts`, requestInit);
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
