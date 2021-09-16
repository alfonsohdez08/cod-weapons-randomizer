# Call of Duty Loadout Randomizer (MW & WZ)

An app that randomizes a Call of Duty Modern Warfare (2019) and Call of Duty Warzone loadout.

## Where the data come from?

All the data displayed in the application has been scraped from the [Call of Duty Wiki](https://callofduty.fandom.com/wiki/Call_of_Duty_Wiki) pages. The web scraper is under the `server` folder as [CodWeaponsRandomizer.CodWebPagesScraper](/server/src/CodWeaponsRandomizer.CodWebPagesScraper).

### Data Accuracy

#### Call of Duty Modern Warfare (2019)

All the weapons, perks, lethals and tacticals have been scraped/imported with no issue.

#### Call of Duty Black Ops Cold War

Due to the CW integration with WZ, CW data has been scraped as well. However, there are 4 weapons missing because the current approach is not able to scrap them:

- Ballistic Knife (a Special weapon for CW, but a Melee weapon for WZ).
- M79 (a Special weapon for CW, but a Launcher weapon for WZ).
- Nail Gun (a Special weapon for CW, but a SMG for WZ).
- R1 Shadowhunter (a Special weapon for CW, but a Tactical Rifle for WZ).

## How to run it locally?

Please, visit to the [client folder](/client/cod-weapons-randomizer/README.md) and [server folder](/server/README.md) so you can find more details about how to run both application components.

## Features roadmap

[ ] Differentiate MW weapons from CW weapons in UI.
[ ] Provide a Warzone loadout hint to select a weapon from each game.
[ ] Able to share loadout.

## Disclaimer

This App is not endorsed by Activision and its subsidiaries, nor the
data displayed here belongs to the App developer. All the data is coming
from [Call of Duty Wiki](https://callofduty.fandom.com/wiki/Call_of_Duty_Wiki).
