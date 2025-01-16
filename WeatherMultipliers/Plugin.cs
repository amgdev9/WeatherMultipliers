using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

public class PluginInfo
{
    public const string PLUGIN_GUID = "com.github.jaredlll08.WeatherMultipliers";
    public const string PLUGIN_NAME = "Weather Multipliers";
    public const string PLUGIN_VERSION = "1.0.0";
}

namespace WeatherMultipliers
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        public static new Config Config { get; internal set; }
        internal static new ManualLogSource Logger { get; private set; }
        private readonly Harmony harmony = new Harmony(PluginInfo.PLUGIN_GUID);

        private void Awake()
        {
            Config = new Config(base.Config);
            Logger = base.Logger;

            harmony.PatchAll();
            harmony.PatchAll(typeof(Config));
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
        }
    }
}
