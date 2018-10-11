using System;

namespace PlayerInfoPlugin.Misc
{
    class DefaultInfoManager : IInfoManager
    {
        public string Platform => "Default";

        public string Username { get; private set; }
        public ulong UserID { get; private set; }
        public string Proof => null;

        public event Action<string, ulong> PlayerInfoLoaded;
        public event Action<string> PlayerProofGenerated;

        public void LoadPlayerInfo()
        {
            Username = "Player";
            UserID = 0;
        }

        public void RequestPlayerProof() { }
    }
}
