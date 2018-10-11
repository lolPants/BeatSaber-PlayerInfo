using System;
using PlayerInfoPlugin.Misc;
using Steamworks;

namespace PlayerInfoPlugin.Steam
{
    public class InfoManager : IInfoManager
    {
        public string Platform => "Steam";

        public string Username { get; private set; }
        public ulong UserID { get; private set; }

        public event Action<string, ulong> PlayerInfoLoaded;

        public void LoadPlayerInfo()
        {
            if (Username == null || UserID == 0)
            {
                Username = SteamFriends.GetPersonaName();
                UserID = SteamUser.GetSteamID().m_SteamID;

                PlayerInfoLoaded.Invoke(Username, UserID);
            }
        }
    }
}
