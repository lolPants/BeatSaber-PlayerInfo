using System;
using PlayerInfoPlugin.Misc;
using Oculus.Platform;
using Oculus.Platform.Models;

namespace PlayerInfoPlugin.Oculus
{
    public class InfoManager : IInfoManager
    {
        public string Platform => "Oculus";

        public string Username { get; private set; }
        public ulong UserID { get; private set; }

        public void LoadPlayerInfo()
        {
            if (Username == null || UserID == 0)
            {
                Users.GetLoggedInUser().OnComplete((Message<User> msg) =>
                {
                    Username = msg.Data.OculusID;
                    UserID = msg.Data.ID;
                });
            }
        }
    }
}
