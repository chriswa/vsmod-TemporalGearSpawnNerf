using Vintagestory.API.Common;
using Vintagestory.API.Common.Entities;
using Vintagestory.API.Server;

namespace TemporalGearSpawnNerf {
  public class ClearSpawnPosAfterReviveEntityBehavior : EntityBehavior {
    private ModConfig config;
    public ClearSpawnPosAfterReviveEntityBehavior(Entity entity, ModConfig config) : base(entity) {
      this.config = config;
    }
    public override string PropertyName() {
      return "ClearSpawnPosAfterReviveEntityBehavior";
    }
    public override void OnEntitySpawn() {
      // doesn't work!

      // IServerPlayer player = GetIServerPlayer();
      // if (IsDefaultSpawn(player)) {
      //   SendChatMessage(player, "Your spawn point remains unset.");
      // }
      // else {
      //   SendChatMessage(player, "Your spawn point remains set.");
      // }
      
      base.OnEntitySpawn();
    }
    public override void OnEntityDeath(DamageSource damageSourceForDeath) {
      if (config.ChanceOfSpawnFailure > 0) {
        IServerPlayer player = GetIServerPlayer();
        if (this.entity.World.Rand.NextDouble() < config.ChanceOfSpawnFailure) {
          player.ClearSpawnPosition();
          Util.SendChatMessage(player, "Catastrophe! Your spawn point has failed!");
        }
      }

      base.OnEntityDeath(damageSourceForDeath);
    }
    public override void OnEntityRevive() {
      IServerPlayer player = GetIServerPlayer();
      if (!Util.IsDefaultSpawn(player)) {
        if (this.entity.World.Rand.NextDouble() < config.ChanceOfSpawnClear) {
          player.ClearSpawnPosition();
          Util.SendChatMessage(player, "You have respawned at your spawn point, but the link fades. Your spawn point has been lost. You will need to use another Temporal Gear to set your spawn point again.");
        }
        else {
          Util.SendChatMessage(player, "You have respawned at your spawn point, and the link remains strong. It is not necessary to use another Temporal Gear.");
        }
      }

      base.OnEntityRevive();
    }
    private IServerPlayer GetIServerPlayer() {
      return this.entity.World.PlayerByUid((this.entity as EntityPlayer).PlayerUID) as IServerPlayer;
    }
  }
}