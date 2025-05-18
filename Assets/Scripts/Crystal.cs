using UnityEngine;

public class Crystal : Pickup
{
    public int points;

    public override void Picked()
    {
        GameManager.gameManager.AddPoints(points);
        base.Picked();
    }
}
