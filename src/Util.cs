using Vintagestory.API.Common;
using Vintagestory.API.Server;
using Vintagestory.API.Config;

namespace TemporalGearSpawnNerf {
  public class Util {
    public static bool IsDefaultSpawn(IServerPlayer player) {
      return player.SpawnPosition.AsBlockPos.Equals(player.Entity.World.DefaultSpawnPosition.AsBlockPos);
    }
    public static void SendChatMessage(IServerPlayer player, string message, params object[] param) {
      player.SendMessage(GlobalConstants.GeneralChatGroup, Lang.Get(message, param), EnumChatType.Notification);
    }
  }
}