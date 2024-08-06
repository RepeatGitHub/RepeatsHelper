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
        Depth = 100;
        AddTag(Tags.Persistent);
    }

    public override void Update() {
        base.Update();
    }

    public override void Render() {
        base.Render();
        Player self = RepeatsHelperModule.Session.thisPlayer;
        if (self!=null) {
            //Logger.Log(LogLevel.Warn,"temp1",RepeatsHelperModule.Session.drawIt[0]+"a"+RepeatsHelperModule.Session.backItem);
            if(RepeatsHelperModule.Session.hasMarkOfCommunication) {
                // If player facing right, flipNum is 1. Else, it's -1.
                GFX.Game["util/pixel"].Draw(new Microsoft.Xna.Framework.Vector2 (Convert.ToInt16(self.X),Convert.ToInt16(self.Y)), new Microsoft.Xna.Framework.Vector2 (0,0), Color.White, new Microsoft.Xna.Framework.Vector2 (2,2));
            }
        }
    }
}