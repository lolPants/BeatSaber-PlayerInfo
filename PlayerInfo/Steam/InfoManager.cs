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
        public string Proof { get; private set; }

        public event Action<string, ulong> PlayerInfoLoaded;
        public event Action<string> PlayerProofGenerated;

        private byte[] _ticketBlob = new byte[1024];
        private uint _ticketSize;

        private Callback<GetAuthSessionTicketResponse_t> m_GetAuthSessionTicketResponse;

        public void LoadPlayerInfo()
        {
            if (Username == null || UserID == 0)
            {
                Username = SteamFriends.GetPersonaName();
                UserID = SteamUser.GetSteamID().m_SteamID;

                PlayerInfoLoaded.Invoke(Username, UserID);
            }
        }

        public void RequestPlayerProof()
        {
            Proof = null;

            if (m_GetAuthSessionTicketResponse == null)
                m_GetAuthSessionTicketResponse = Callback<GetAuthSessionTicketResponse_t>.Create(OnGetAuthSessionTicketResponse);

            SteamUser.GetAuthSessionTicket(_ticketBlob, 1024, out _ticketSize);
        }

        private void OnGetAuthSessionTicketResponse(GetAuthSessionTicketResponse_t result)
        {
            string steamSessionticket = BitConverter.ToString(_ticketBlob, 0, (int)_ticketSize).Replace("-", "").ToLowerInvariant();
            PlayerProofGenerated.Invoke(steamSessionticket);
        }
    }
}
