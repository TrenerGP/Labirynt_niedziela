using UnityEngine;

public class TimeModifier : Pickup
{
    public int timeMod;

    public override void Picked()
    {
        GameManager.gameManager.AddTime(timeMod);
        base.Picked();
    }
}
