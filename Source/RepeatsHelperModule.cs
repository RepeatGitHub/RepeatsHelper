using System;

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
    }

    public override void Unload() {
        Everest.Events.Level.OnLoadLevel -= backItemVisualier;
    }

    private void backItemVisualier(Level self, Player.IntroTypes playerIntro, bool isFromLoader) {
        if (debugMode) {
            self.Add(new backItemVisual());
            self.Add(new markVisual());
        }
    }
}