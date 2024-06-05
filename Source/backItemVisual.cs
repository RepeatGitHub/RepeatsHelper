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

public class backItemVisual : Entity { // this should not show up in ahorn/lonn hopefully
    public backItemVisual() {
        Depth = Depths.Player+1;
        AddTag(Tags.Persistent);
    }

    public override void Update() {
        base.Update();

        // thank u extended variants but im not using this
        //Depth = (Depths.BGTerrain + Depths.BGDecals) / 2;
        Depth = 1;
    }

    public override void Render() {
        base.Render();

        //if (VinkiModModule.Session.vinkiRenderIt[4]!=-1) {
        //    GFX.Game[VinkiModModule.textureReplaceNamespaces[VinkiModModule.Session.vinkiRenderIt[4]]].Draw(new Microsoft.Xna.Framework.Vector2 (VinkiModModule.Session.vinkiRenderIt[5],VinkiModModule.Session.vinkiRenderIt[6]));
        //}
    }
}