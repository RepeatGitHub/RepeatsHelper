namespace Celeste.Mod.RepeatsHelper;

public class RepeatsHelperModuleSession : EverestModuleSession {
    public bool hasMarkOfCommunication = true;
    public int backItem = 1;
    public int drawIt = 0;
    public int howCrouched = 0;
    public Player thisPlayer;
    public int[] lastXY = [0,0];
    public float timeSinceMoved = 0;
    public float markAlpha = 0f;
}