using PlayerInfoPlugin.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerInfoPlugin.Misc
{
    class DefaultInfoManager : IInfoManager
    {
        public string Platform => "Default";

        public string Username { get; private set; }
        public ulong UserID { get; private set; }

        public event Action<string, ulong> PlayerInfoLoaded;

        public void LoadPlayerInfo()
        {
            Username = "Player";
            UserID = 0;
        }
    }
}
