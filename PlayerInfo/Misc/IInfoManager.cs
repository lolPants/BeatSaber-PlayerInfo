using System;

namespace PlayerInfoPlugin.Misc
{
    public interface IInfoManager
    {
        string Platform { get; }

        string Username { get; }
        ulong UserID { get; }

        event Action<string, ulong> PlayerInfoLoaded;

        void LoadPlayerInfo();
    }
}
