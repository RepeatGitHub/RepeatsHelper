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
        RepeatsHelperModule.Session.drawIt=0;
        Player self = null;
        if (Scene.Tracker.GetEntity<Player>()!=null) {
            self = Scene.Tracker.GetEntity<Player>();
        }
        if (self!=null) {
            RepeatsHelperModule.Session.drawIt=1;
        }
        //RepeatsHelperModule.Session.thisPlayer=Scene.Tracker.GetEntity<Player>();
    }

    public override void Render() {
        base.Render();
        Player self = Scene.Tracker.GetEntity<Player>();
        if (self!=null) {
            if (self.Ducking) {
                if (RepeatsHelperModule.Session.howCrouched<4) {
                    RepeatsHelperModule.Session.howCrouched+=1;
                }
            } else if (RepeatsHelperModule.Session.howCrouched>0) {
                RepeatsHelperModule.Session.howCrouched-=1;
            }
            //Logger.Log(LogLevel.Warn,"temp1",RepeatsHelperModule.Session.drawIt[0]+"a"+RepeatsHelperModule.Session.backItem);
            if(RepeatsHelperModule.Session.backItem>-1) {
                var flipped = self.Facing;
                // If player facing right, flipNum is 1. Else, it's -1.
                var flipNum = flipped==Facings.Right?1:-1;
                var losOffsets = RepeatsHelperModule.Instance.offsets[RepeatsHelperModule.Session.backItem];
                GFX.Game["RepeatsHelper/backItems/backitem_"+RepeatsHelperModule.Session.backItem].Draw(new Microsoft.Xna.Framework.Vector2 (Convert.ToInt16(self.X)+losOffsets[0]*flipNum,Convert.ToInt16(self.Y)+losOffsets[1]+RepeatsHelperModule.Session.howCrouched), new Microsoft.Xna.Framework.Vector2 (0,0), Color.White, new Microsoft.Xna.Framework.Vector2 (flipNum,1));
            }
        }
    }
}