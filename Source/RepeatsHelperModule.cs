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
#if DEBUG
        // debug builds use verbose logging
        Logger.SetLogLevel(nameof(RepeatsHelperModule), LogLevel.Verbose);
#else
        // release builds use info logging to reduce spam in log files
        Logger.SetLogLevel(nameof(RepeatsHelperModule), LogLevel.Info);
#endif
    }

    public override void Load() {
        // TODO: apply any hooks that should always be active
    }

    public override void Unload() {
        // TODO: unapply any hooks applied in Load()
    }
}