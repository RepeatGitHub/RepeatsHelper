using System;
using System.Reflection;
using System.Numerics;
using MonoMod.Utils;
using MonoMod.ModInterop;
using MonoMod.RuntimeDetour;
using Celeste;
using Celeste.Mod;
using Celeste.Mod.UI;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Monocle;

namespace Celeste.Mod.RepeatsHelper;

public class markVisual : Entity {
    public markVisual() {
        Depth = -8669;
        AddTag(Tags.Persistent);
    }

    public override void Update() {
        base.Update();
    }

    public override void Render() {
        base.Render();
        Player self = RepeatsHelperModule.Session.thisPlayer;
        if (self!=null) {
            if(RepeatsHelperModule.Session.hasMarkOfCommunication) {
                GFX.Game["util/pixel"].Draw(new Microsoft.Xna.Framework.Vector2 (Convert.ToInt16(self.X)-1,Convert.ToInt16(self.Y)-25), new Microsoft.Xna.Framework.Vector2 (0,0), new Color(new Microsoft.Xna.Framework.Vector4 (Convert.ToInt16(255),Convert.ToInt16(255),Convert.ToInt16(255),Convert.ToInt16(127))), new Microsoft.Xna.Framework.Vector2 (1,1));
            }
        }
    }
}