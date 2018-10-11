using System;
using UnityEngine.SceneManagement;
using PlayerInfoPlugin.Misc;
using IllusionPlugin;

namespace PlayerInfoPlugin
{
    public class Plugin : IPlugin
    {
        public string Name => "PlayerInfo";
        public string Version => "0.1.0";

        public void OnApplicationStart()
        {
            SceneManager.sceneLoaded += SceneLoaded;
        }

        private void SceneLoaded(Scene scene, LoadSceneMode arg1)
        {

        }

        public void OnApplicationQuit()
        {
            SceneManager.sceneLoaded -= SceneLoaded;
        }

        public void OnFixedUpdate() { }

        public void OnLevelWasInitialized(int level) { }

        public void OnLevelWasLoaded(int level) { }

        public void OnUpdate() {}
    }

    public static class PlayerInfo
    {
        public static IInfoManager Manager = new DefaultInfoManager();
    }
}
