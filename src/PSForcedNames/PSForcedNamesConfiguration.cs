using System.Collections.Generic;
using System.Xml.Serialization;
using Rocket.API;

namespace PSForcedNames
{
    public class PSForcedNamesConfiguration : IRocketPluginConfiguration
    {
        public List<Player> Players;
        
        public bool Enabled;
        
        public void LoadDefaults()
        {
            Enabled = true;

            Players = new List<Player>
            {
                new Player {SteamId64 = 76561198132469161, CharacterName = "God Himself"}
            };
        }
    }

    public class Player
    {
        [XmlAttribute] public ulong SteamId64;
        [XmlAttribute] public string CharacterName;
    }
}