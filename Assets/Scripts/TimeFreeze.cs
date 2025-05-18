using UnityEngine;

public class TimeFreeze : Pickup
{
    public int timeFreeze;

    public override void Picked()
    {
        GameManager.gameManager.FreezeTime(timeFreeze);
        base.Picked();
    }
}
