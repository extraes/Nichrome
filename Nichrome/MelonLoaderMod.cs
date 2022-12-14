using BoneLib;
using Jevil;
using MelonLoader;
using SLZ.Bonelab;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nichrome;

public static class NichromeBuildInfo
{
    public const string Name = "Nichrome"; // Name of the Mod.  (MUST BE SET)
    public const string Author = "extraes"; // Author of the Mod.  (Set as null if none)
    public const string Company = null; // Company that made the Mod.  (Set as null if none)
    public const string Version = "1.0.0"; // Version of the Mod.  (MUST BE SET)
    public const string DownloadLink = null; // Download Link for the Mod.  (Set as null if none)
}

public class NichromeMain : MelonMod
{
    public NichromeMain() : base() => instance = this;
    internal static NichromeMain instance;

    internal static List<Chemical> AllChemicals = new();
    //internal readonly static List<Chemical> AllChecmicals = new();

    public override void OnInitializeMelon()
    {
        AllChemicals.AddRange(from Type type in MelonAssembly.Assembly.GetTypes()
        where type.IsSubclassOf(typeof(Chemical))
        select Activator.CreateInstance(type) as Chemical);
    }

    public override void OnSceneWasInitialized(int buildIndex, string sceneName)
    {
        bool notReady = Instances.Player_PhysicsRig.INOC();
#if DEBUG
        Log($"Scene initialized: {sceneName}. Will {(notReady ? "not" : "")} initialize chemicals.");
#endif
        if (notReady) return;

        foreach (Chemical chemical in AllChemicals)
        {
            if (chemical.Enabled) chemical.SceneInitialized();
        }

    }

    #region MelonLogger replacements

    internal static void Log(string str) => instance.LoggerInstance.Msg(str);
    internal static void Log(object obj) => instance.LoggerInstance.Msg(obj?.ToString() ?? "null");
    internal static void Warn(string str) => instance.LoggerInstance.Warning(str);
    internal static void Warn(object obj) => instance.LoggerInstance.Warning(obj?.ToString() ?? "null");
    internal static void Error(string str) => instance.LoggerInstance.Error(str);
    internal static void Error(object obj) => instance.LoggerInstance.Error(obj?.ToString() ?? "null");

    #endregion
}
