using Vintagestory.API.Common;
using Vintagestory.API.Common.Entities;
using Vintagestory.API.Server;

[assembly: ModInfo("TemporalGearSpawnNerf")]

namespace TemporalGearSpawnNerf {
  public class TemporalGearSpawnNerf : ModSystem {

    private ModConfig config;
    public override void StartServerSide(ICoreServerAPI api) {

      // load config file or write it with defaults
      config = api.LoadModConfig<ModConfig>("TemporalGearSpawnNerfConfig.json");
      if (config == null) {
        config = new ModConfig();
        api.StoreModConfig(config, "TemporalGearSpawnNerfConfig.json");
      }

      // OnEntitySpawn fires when player joins, not when player respawns
      api.Event.OnEntitySpawn += (Entity entity) => {
        if (entity is EntityPlayer) {
          api.Logger.Debug("Adding ClearSpawnPosAfterReviveEntityBehavior to spawned EntityPlayer");
          entity.AddBehavior(new ClearSpawnPosAfterReviveEntityBehavior(entity, config));
        }
      };

      api.Event.PlayerJoin += (IServerPlayer player) => {
        if (Util.IsDefaultSpawn(player)) {
          Util.SendChatMessage(player, "Your spawn point has not been set.");
        }
        else {
          Util.SendChatMessage(player, "Your spawn point has been set.");
        }
      };
    }
  }


}
