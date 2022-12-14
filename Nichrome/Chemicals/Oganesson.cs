using Jevil;
using Jevil.Patching;
using Jevil.Prefs;
using SLZ.Bonelab;
using SLZ.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nichrome.Chemicals;

public sealed class Oganesson : Chemical
{
    public override string Name => nameof(Oganesson);
    public override string Description => "Conserve your munitions. They don't fill ammo boxes as much as they used to.";
    public override bool Enabled => ammoShortage;
    [Pref] static bool ammoShortage = true;
    [Pref] static bool clearAmmoOnLoad = true;

    public Oganesson()
    {
        Hook.OntoMethod(typeof(AmmoPickup).GetMethod(nameof(AmmoPickup.Awake), Const.AllBindingFlags), ChangeAmmoCount);
        Hook.OntoMethod(typeof(AmmoInventory).GetMethod(nameof(AmmoInventory.Awake), Const.AllBindingFlags), ResetAmmoOnLoad);
    }

    static void ChangeAmmoCount(AmmoPickup pickup)
    {
#if DEBUG
        NichromeMain.Log($"{nameof(Oganesson)} is {(ammoShortage ? "enabled" : "disabled")} and recieved a patch callback from pickup named '{pickup.name}'");
#endif
        if (ammoShortage) 
            pickup.ammoCount = 1;
    }
    
    static void ResetAmmoOnLoad(AmmoInventory inv)
    {
#if DEBUG
        NichromeMain.Log($"{nameof(Oganesson)} is {(ammoShortage ? "enabled" : "disabled")} and recieved a patch callback from ammoinventory named '{inv.name}'");
#endif
        if (clearAmmoOnLoad) 
            inv.ClearAmmo();
    }
}
