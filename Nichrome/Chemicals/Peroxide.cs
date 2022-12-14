using Jevil;
using Jevil.Patching;
using Jevil.Prefs;
using SLZ.Bonelab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nichrome.Chemicals;

public sealed class Peroxide : Chemical
{
    public override string Name => nameof(Peroxide);
    public override string Description => "Healing is a luxury you no longer have.";
    public override bool Enabled => noRegen;
    [Pref] static bool noRegen = true;
    [Pref] static bool noRevive = true;

    public Peroxide()
    {
        Hook.OntoMethod(typeof(Player_Health).GetMethod(nameof(Player_Health.OnEnable)), ChangeHealth);
    }

    public static void ChangeHealth(Player_Health pHealth)
    {
        Player_Health health = pHealth;
        if (noRegen)
        {
            // could float.positiveinfinity but i doubt anyone is gonna be in BL for 278 hours in the same level
            health.wait_Regen_t = 999999;
            health.totalRegenDuration = 999999;
#if DEBUG
            NichromeMain.Log($"{nameof(Peroxide)} No Regen is enabled and has set regentime to {health.wait_Regen_t} and regenduration to {health.totalRegenDuration}");
#endif
        }

        if (noRevive)
        {
            health.SetHealthMode((int)Health.HealthMode.Mortal);
            health._testRagdollOnDeath = true;
            //health.isInstaDying = true; not really necessary as i doubt anyone would come back from ragdolling anyway
#if DEBUG
            NichromeMain.Log($"{nameof(Peroxide)} No Revive is enabled and has set healthmode to {health.healthMode}");
#endif
        }
    }


}
