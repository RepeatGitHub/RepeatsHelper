using System;
using Microsoft.Xna.Framework;
using Monocle;

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

    // but here's the commands
    [Command("ss_set_inv", "(Sacred Solitude) displays syntax of this command")]
    public static void cmdSetInvHelp() {
        Engine.Commands.Log($"Syntax for the ss_set_inv command:");
        Engine.Commands.Log($"- \"ss_set_inv\": Shows this help message.");
        Engine.Commands.Log($"- \"ss_set_inv mark <true/false>\": Sets the Mark of Communication to on or off.");
        Engine.Commands.Log($"- \"ss_set_inv backitem <0/1/...>\": Sets the player's back item to whatever is input, as long as what's input to the command is an integer within the valid range of items.");
    }

    [Command("ss_set_inv mark", "(Sacred Solitude) sets the mark of communication's status")]
    public static void cmdSetInvMark(bool trueOrNot) {
        Session.hasMarkOfCommunication = trueOrNot;
    }

    [Command("ss_set_inv backitem", "(Sacred Solitude) sets the back item (0 is no item)")]
    public static void cmdSetInvBackItem(int itemNum) {
        if (itemNum>-1&&itemNum<2) {
            Session.backItem = itemNum;
        } else {
            Engine.Commands.Log($"Invalid item! Use an integer between 0-1.");
        }
    }
}