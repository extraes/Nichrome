using Jevil.Prefs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nichrome;

[PreferencesRegisterChildren(false)]
[Preferences("Nichrome", true)]
public abstract class Chemical
{
    static Chemical() => Preferences.Register(typeof(Chemical));

    public abstract string Name { get; }
    public abstract string Description { get; }
    public abstract bool Enabled { get; }

    public virtual void SceneInitialized() { }

    public virtual void Update() { }

}
