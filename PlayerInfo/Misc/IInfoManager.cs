using System;

namespace PlayerInfoPlugin.Misc
{
    public interface IInfoManager
    {
        string Platform { get; }

        string Username { get; }
        ulong UserID { get; }
        string Proof { get; }

        event Action<string, ulong> PlayerInfoLoaded;
        event Action<string> PlayerProofGenerated;

        void LoadPlayerInfo();
        void RequestPlayerProof();
    }
}
