using System;

namespace PlayerInfoPlugin.Misc
{
    public class Platform
    {
        /// <summary>
        /// The different types of releases of the game.
        /// </summary>
        public enum Release
        {
            /// <summary>
            /// Indicates a Steam release.
            /// </summary>
            Steam,
            /// <summary>
            /// Indicates an Oculus release.
            /// </summary>
            Oculus
        }

        private static Release? _releaseCache = null;
        /// <summary>
        /// Gets the <see cref="Release"/> type of this installation of Beat Saber
        /// </summary>
        public static Release ReleaseType => (_releaseCache ?? (_releaseCache = FindSteamVRAsset() ? Release.Steam : Release.Oculus)).Value;

        private static bool FindSteamVRAsset()
        {
            // these require assembly qualified names....
            var SteamVRCamera = Type.GetType("SteamVR_Camera, Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", false);
            var SteamVRExternalCamera = Type.GetType("SteamVR_ExternalCamera, Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", false);
            var SteamVRFade = Type.GetType("SteamVR_Fade, Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", false);

            return SteamVRCamera != null && SteamVRExternalCamera != null && SteamVRFade != null;
        }
    }
}
