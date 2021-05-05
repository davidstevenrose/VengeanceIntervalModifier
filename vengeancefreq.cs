using BepInEx;
using BepInEx.Configuration;
using R2API.Utils;
using RoR2;
using UnityEngine;
using System;

namespace VengeanceFreq
{
    [BepInDependency("com.bepis.r2api", BepInDependency.DependencyFlags.HardDependency)]
    [BepInPlugin("com.Shamus.VengeanceFreq", "VengeanceFreq", "1.0.0")]
    [R2APISubmoduleDependency(nameof(CommandHelper))]
    public class VengeanceModify : BaseUnityPlugin
    {
        private static ConfigEntry<String> IntervalConfig { get; set; }

        private delegate int RunInstanceReturnInt(Run self);

        public static int Multiplier
        {
            get {
                try
                {
                    return int.Parse(IntervalConfig.Value);
                }
                catch (FormatException)
                {
                    print("Invalid vengeance period input " + Multiplier + ", resetting to default value");
                    return 600;
                }
            }
            set => IntervalConfig.Value = value.ToString();
        }

        public void Awake()
        {
            IntervalConfig = Config.Bind(
                "Game",
                "Interval",
                "600",
                "Sets the period for vengeance in seconds. Must be an integer greater than or equal to 1.");

            On.RoR2.Console.Awake += (orig, self) =>
            {
                CommandHelper.AddToConsoleWhenReady();
                orig(self);
                if (Multiplier <= 0)
                {
                    print("Invalid vengeance period of " + Multiplier + " seconds, resetting to default value");
                    Multiplier = 600;
                }
                print("vengeance period: " + Multiplier);
            };

            On.RoR2.Artifacts.DoppelgangerInvasionManager.GetCurrentInvasionCycle += getCustomInvCycle;
        }
        
        private int getCustomInvCycle(On.RoR2.Artifacts.DoppelgangerInvasionManager.orig_GetCurrentInvasionCycle orig, RoR2.Artifacts.DoppelgangerInvasionManager self)
        {
            return Mathf.FloorToInt(Run.instance.GetRunStopwatch() / Multiplier);
        }

        [ConCommand(commandName = "set_vengeance_period", flags = ConVarFlags.None, helpText = "Sets the period for Vengeance in seconds. Must in range 1-1200")]
        private static void setVengeancePeriod(ConCommandArgs args)
        {
            try
            {
                int time = int.Parse(args[0]);
                if(time > 0 && time <= 1200)
                {
                    Multiplier = time;
                }
                else
                {
                    print("The period must be between 1 and 1200 seconds.");
                }
            }catch(FormatException)
            {
                print("Invalid input: first arg requires an integer");
            }
        }
    }
}
