using Jevil;
using Jevil.Patching;
using Jevil.Prefs;
using PuppetMasta;
using SLZ.AI;
using SLZ.Bonelab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nichrome.Chemicals;

public sealed class Magnesium : Chemical
{
    public override string Name => nameof(Magnesium);
    public override string Description => "Storing energy for a flashy release. Your enemies are going to be able to get you from range.";
    public override bool Enabled => allNullsThrow;
    [Pref] static bool allEnemiesThrow = false;
    [Pref] static bool allNullsThrow = true;

    public Magnesium()
    {
        Hook.OntoMethod(typeof(AIBrain).GetMethod(nameof(AIBrain.OnSpawn), Const.AllBindingFlags), ChangeBehaviour);
        //Hook.OntoMethod(typeof(BehaviourPowerLegs).GetMethod(nameof(BehaviourPowerLegs.OnInitiate), Const.AllBindingFlags), PeekBehaviour);
    }

    static void ChangeBehaviour(AIBrain brain)
    {
#if DEBUG
        NichromeMain.Log($"{nameof(Magnesium)} is {(allNullsThrow ? "enabled" : "disabled")} and recieved a patch callback from AIBrain named '{brain.name}' (parent named '{brain.transform.parent?.name ?? "NOPARENT"}')");
#endif
        if (allEnemiesThrow)
        {
            brain.behaviour.enableThrowAttack = true;

        }
        else if (allNullsThrow && brain.name.Contains("NullBody"))
        {
            brain.behaviour.enableThrowAttack = true;
            //brain.behaviour.baseConfig.enableThrowAttack = true;
            //brain.SetBaseConfig(brain.behaviour.baseConfig); // should work? will need to test
            //todo: test
        }
    }

    // dead code, never used in production. behaviourbasenav.baseconfig is always null because THANKS SLZ
    static void PeekBehaviour(BehaviourPowerLegs bpl)
    {
        if (bpl.INOC()) return;
        NichromeMain.Log($"{nameof(Magnesium)} is {(allNullsThrow ? "enabled" : "disabled")} and recieved a patch callback from BehaviourBaseNav named '{bpl.name}' (parent named '{bpl.transform.parent.name}'). Now logging its behaviour.");
        NichromeMain.Log($"BehaviourPowerLegs: {bpl.ToString()}");
        NichromeMain.Log($"Spawnable: {bpl.spawnable.ToString()}");
        NichromeMain.Log($"Spawnable crate: {bpl.spawnable.crateRef.ToString()}");
        NichromeMain.Log($"Spawnable barcode: {bpl.spawnable.crateRef.Barcode.ToString()}");
        NichromeMain.Log($"Spawnable pallet barcode: {bpl.spawnable.crateRef.PalletBarcode.ToString()}");
        NichromeMain.Log($"BaseConfig: {bpl.baseConfig.ToString()}");
        NichromeMain.Log($"BaseConfig name: {bpl.baseConfig.name}");
        NichromeMain.Log($"throwCooldown: {bpl.baseConfig.throwCooldown}");
        NichromeMain.Log($"throwMaxRange: {bpl.baseConfig.throwMaxRange}");
        NichromeMain.Log($"throwMinRange: {bpl.baseConfig.throwMinRange}");
        NichromeMain.Log($"throwVelocity: {bpl.baseConfig.throwVelocity}");
        NichromeMain.Log($"enableThrowAttack: {bpl.baseConfig.enableThrowAttack}");
        NichromeMain.Log($"throwAttackUsesGravity: {bpl.throwAttackUsesGravity}");
    }
}
