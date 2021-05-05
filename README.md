# Vengeance Interval Modifier

## Description

Change the time of how often your evil doppelganger spawns with Vengeance enabled. This is configurable from the config file and the in-game console.

## Installation

Use **[r2modman](https://thunderstore.io/package/ebkr/r2modman/)** mod manager to install this mod.

Without the use of a mod manager, the DLL can be obtained from **[Thunderstore](https://thunderstore.io/package/Shamus/Vengeance_Interval_Modifier/)**. Place the DLL in its own folder within your `/plugins` folder.

## Usage
### Config file
After launching the game with this mod for the first time, navigate to the `/config` directory where your config files are located. 
In `com.Shamus.VengeanceFreq.cfg`, set the interval field to the time in seconds of when the Vengeance artifact spawns the doppelgangers.
Save the config file and restart the game to reflect the new change.

### Console
Open the console using `Ctrl+Alt+~`. Use the command `set_vengeance_period <time>` to change the interval to `<time>` seconds.
The time argument must be an integer between 1 and 1200 seconds.

## Contact
- Issue Page: https://github.com/davidstevenrose/VengeanceIntervalModifier/issues
- Discord: `Shamus#1865`
- RoR2 Modding Server: https://discord.com/invite/5MbXZvd

## Changelog
**1.0.0**
- Initial release.