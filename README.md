# vsmod-TemporalGearSpawnNerf

A Vintage Story mod which clears your spawn point (if set by a Temporal Gear) after respawning.

## Overview

When you die in Wilderness Survival, you respawn a random distance away, usually extremely far. Finding your old base is difficult or impossible, making the experience somewhat like permadeath. However, once you've obtained a Temporal Gear (which you can get by panning 7 stacks of sand or grinding 50 drifters,) this mechanic is nullified because the gear can be used to permanently set your spawn point. After finding a gear, you can comfortably dance off into the woods at night to feed the wolves, over and over, and never lose your base.

This mod revives the fear of death by clearing your spawn point after you respawn. This means that, if you use a Temporal Gear, die, and respawn at your base, you'll need to use another Temporal Gear to set your spawn point again.

## Customization

After being run the first time, this mod will create a config file at `%appdata%/VintagestoryData/ModConfig/TemporalGearSpawnNerf.json`. You can modify this file to change some settings.

If you want to make things a bit easier, you can lower `ChanceOfSpawnClear` from 100% (1.0) to 25% (0.25) so that you'll (on average) only need to re-gear every 4 deaths. A chat message appears after you respawn, letting you know if your spawn point has been lost.

If you want to make things a bit more terrifying, you can enable Spawn Failures. This feature causes spawn points to sometimes fail before you respawn, meaning that even if you have geared, you may end up lost. To enable this awful, horrible feature, raise `ChanceOfSpawnFailure` from 0% (0.0) to 5% (0.05).

## Adding to an Existing World

If you have already used a gear, your spawn point will be preserved. You'll need to worry about losing it after you die and respawn at your base.
