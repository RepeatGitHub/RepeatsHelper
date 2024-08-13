using System;
using System.Reflection;
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
    private float timeSinceMoved = 0;
    private float markAlpha = 0f;
    public markVisual() { // this is called a constructor
        Depth = -8669;
        AddTag(Tags.Persistent);
        //Add(new BloomPoint(new Vector2(RepeatsHelperModule.Session.lastXY[0],RepeatsHelperModule.Session.lastXY[1]), RepeatsHelperModule.Session.markAlpha, 8));
    }

    public override void Update() {
        base.Update();
        Player self = RepeatsHelperModule.Session.thisPlayer;
        // calculation
        if (self!=null) {
            if (RepeatsHelperModule.Session.lastXY[0]==Convert.ToInt16(self.X)&&RepeatsHelperModule.Session.lastXY[1]==Convert.ToInt16(self.Y)) {
                timeSinceMoved+=Engine.DeltaTime;
            } else {
                timeSinceMoved=0;
            }
            if (timeSinceMoved>=1) {
                markAlpha=Calc.Approach(markAlpha,1f,1f*Engine.DeltaTime);
            } else {
                markAlpha=Calc.Approach(markAlpha,0f,2f*Engine.DeltaTime);
            }
            RepeatsHelperModule.Session.lastXY=[Convert.ToInt16(self.X),Convert.ToInt16(self.Y)];
        } else {
            timeSinceMoved=0;
            markAlpha=0;
        }
    }

    public override void Render() {
        base.Render();
        Player self = RepeatsHelperModule.Session.thisPlayer;
        // rendering
        if (self!=null) {
            if(RepeatsHelperModule.Session.hasMarkOfCommunication&&markAlpha>0) {
                GFX.Game["util/pixel"].Draw(new Vector2 (Convert.ToInt16(self.X)-1,Convert.ToInt16(self.Y)-25), new Vector2 (0,0), new Color(new Vector3 (Convert.ToInt16(255),Convert.ToInt16(255),Convert.ToInt16(255)))*markAlpha, new Vector2 (1,1));
            }
            //Logger.Log(LogLevel.Warn,"temp1",markAlpha.ToString());
        }
    }
}