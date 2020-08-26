using System.Collections.Generic;
using System.Linq;
using Rocket.API;
using Rocket.Core.Logging;
using Rocket.Core.Plugins;
using Rocket.Unturned.Permissions;
using SDG.Unturned;
using Steamworks;

namespace PSForcedNames
{
    public class PSForcedNames : RocketPlugin<PSForcedNamesConfiguration>
    {
        public PSForcedNames Instance;
        
        protected override void Load()
        {
            Instance = this;
            Logger.LogWarning("[PSForcedNames] Loaded, made by papershredder432, join the support Discord here: https://discord.gg/ydjYVJ2");

            if (!Instance.Configuration.Instance.Enabled) UnloadPlugin();
            
            UnturnedPermissions.OnJoinRequested += OnJoinRequested;
        }
        
        protected override void Unload()
        {
            Instance = null;
            Logger.LogWarning("[PSForcedNames] Unloaded.");
        }
        
        private void OnJoinRequested(CSteamID player, ref ESteamRejection? rejectionreason)
        {
            SteamPending steamPending =
                Provider.pending.FirstOrDefault(x => x.playerID.steamID.m_SteamID == player.m_SteamID);

            if (Instance.Configuration.Instance.Players.Exists(x =>
                x.SteamId64 == steamPending.playerID.steamID.m_SteamID))
            {
                var find = Instance.Configuration.Instance.Players.Find(y => y.SteamId64 == player.m_SteamID);
                steamPending.playerID.characterName = find.CharacterName;

                Logger.Log($"Player \"{steamPending.playerID.playerName}\" has been renamed to \"{find.CharacterName}\".");
            }
            else return;
        }
    }
}