using com.opusmagus.wu.dtl;

namespace com.opusmagus.wu.bl;

public class NPCBO
{
    public enum ActionTypeEnum { Move=0, AttackOpponent=1, AttackCastle=2 };
    public ActionBO TakeAction(NPCDTO npc)
    {
        var rand = new Random();
        int actionIndex=rand.Next()%3;
        var action=(ActionTypeEnum)actionIndex;
        Console.WriteLine($"action=[{action}]");
        switch(action) {
            case ActionTypeEnum.Move: return new MoveActionBO();
            case ActionTypeEnum.AttackOpponent: return new AttackActionBO();
            case ActionTypeEnum.AttackCastle: return new AttackCastleBO();
            default: return new ConfusedActionBO();
        }
    }
}