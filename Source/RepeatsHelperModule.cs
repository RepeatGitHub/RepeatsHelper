using System;

namespace Celeste.Mod.RepeatsHelper;

public class RepeatsHelperModule : EverestModule {
    public static RepeatsHelperModule Instance { get; private set; }

    public override Type SettingsType => typeof(RepeatsHelperModuleSettings);
    public static RepeatsHelperModuleSettings Settings => (RepeatsHelperModuleSettings) Instance._Settings;

    public override Type SessionType => typeof(RepeatsHelperModuleSession);
    public static RepeatsHelperModuleSession Session => (RepeatsHelperModuleSession) Instance._Session;

    public override Type SaveDataType => typeof(RepeatsHelperModuleSaveData);
    public static RepeatsHelperModuleSaveData SaveData => (RepeatsHelperModuleSaveData) Instance._SaveData;

    public RepeatsHelperModule() {
        Instance = this;
    }
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
        }
    }
}