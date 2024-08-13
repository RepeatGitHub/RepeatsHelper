using System;
using Microsoft.Xna.Framework;

namespace Celeste.Mod.RepeatsHelper;

public class RepeatsHelperModule : EverestModule {
    public static RepeatsHelperModule Instance { get; private set; }

    public override Type SessionType => typeof(RepeatsHelperModuleSession);
    public static RepeatsHelperModuleSession Session => (RepeatsHelperModuleSession) Instance._Session;

    public RepeatsHelperModule() {
        Instance = this;
    }
    //but here's the constants
    public int[][] offsets = [[-9,-15],[-9,-15]];
    public bool debugMode = true;

    public override void Load() {
        Everest.Events.Level.OnLoadLevel += backItemVisualier;
        On.Celeste.Player.ctor += onPlayerCtor;
    }

    public override void Unload() {
        Everest.Events.Level.OnLoadLevel -= backItemVisualier;
        On.Celeste.Player.ctor -= onPlayerCtor;
    }

    private void backItemVisualier(Level self, Player.IntroTypes playerIntro, bool isFromLoader) {
        if (debugMode) {
            self.Add(new backItemVisual());
            //self.Add(new markVisual());
        }
    }

    private static void onPlayerCtor(On.Celeste.Player.orig_ctor orig, Player self, Vector2 position, PlayerSpriteMode spriteMode) {
        orig(self, position, spriteMode);
        self.Add(new markVisual2(true,true));
    }
}