using Jevil;
using Jevil.Patching;
using Jevil.Prefs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Nichrome.Chemicals;

public sealed class Quartz : Chemical
{
    public override string Name => "Quartz";
    public override string Description => "Timekeeper: makes sure everything is in realtime.";
    public override bool Enabled => disableSlowmo;
    [Pref] static bool disableSlowmo = true;

    public Quartz() 
    {
        Disable.When(IsEnabled, typeof(Control_GlobalTime).GetMethod(nameof(Control_GlobalTime.DECREASE_TIMESCALE)));
        Disable.When(IsEnabled, typeof(Control_GlobalTime).GetMethod(nameof(Control_GlobalTime.INCREASE_TIMESCALE)));
    }

    static bool IsEnabled()
    {
#if DEBUG
        NichromeMain.Log($"{nameof(Oganesson)} is {(disableSlowmo ? "enabled" : "disabled")} and recieved a patch callback from globaltime. Current timescale is {Time.timeScale}");
#endif
        return disableSlowmo;
    }
}
