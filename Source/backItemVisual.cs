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

public class backItemVisual : Entity {
    public backItemVisual() {
        Depth = Depths.Player+1;
        AddTag(Tags.Persistent);
    }

    public override void Update() {
        base.Update();
        Depth = 1;
        RepeatsHelperModule.Session.drawIt[0]=0;
        Player self = null;
        if (Scene.Tracker.GetEntity<Player>()!=null) {
            self = Scene.Tracker.GetEntity<Player>();
        }
        if (self!=null) {
            RepeatsHelperModule.Session.drawIt=[1,Convert.ToInt16(self.X)+0,Convert.ToInt16(self.Y)+0];
        }
    }

    public override void Render() {
        base.Render();

        Logger.Log(LogLevel.Warn,"temp1",RepeatsHelperModule.Session.drawIt[0]+"a"+RepeatsHelperModule.Session.backItem);
        if (RepeatsHelperModule.Session.drawIt[0]!=0) {
            GFX.Game["RepeatsHelper/backItems/backitem_"+RepeatsHelperModule.Session.backItem].Draw(new Microsoft.Xna.Framework.Vector2 (RepeatsHelperModule.Session.drawIt[1],RepeatsHelperModule.Session.drawIt[2]));
        }
    }
}