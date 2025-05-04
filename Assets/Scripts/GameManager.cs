using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    public int timeToEnd;
    bool win = false;

    private void Start()
    {
        if (gameManager == null) gameManager = this;
        InvokeRepeating("Stopper", 1f, 1f);
    }

    void Stopper()
    {
        timeToEnd--;
        Debug.Log($"Time: {timeToEnd}s");
        if (timeToEnd <= 0)
        {
            EndGame();
            //Time.timeScale = 0f;
        }
    }

    void EndGame()
    {
        CancelInvoke("Stopper");
        if (win)
        {
            Debug.Log("You Win!!! Reload?");
        }
        else
        {
            Debug.Log("You Lose!!! Reload?");
        }
    }
}
