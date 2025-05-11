using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    public int timeToEnd;
    public int points;
    public int redKey;
    public int greenKey;
    public int blueKey;

    bool win = false;
    bool gamePaused = false;

    private void Start()
    {
        if (gameManager == null) gameManager = this;
        InvokeRepeating("Stopper", 1f, 1f);
    }

    public void AddTime(int time)
    {
        timeToEnd += time;
    }

    public void AddPoints(int p)
    {
        points += p;
    }

    public void FreezeTime(int freezeTime)
    {
        CancelInvoke("Stopper");
        InvokeRepeating("Stopper", freezeTime, 1f);
    }


    public void AddKey(KeyColor colorKey)
    {
        if (colorKey == KeyColor.Red) redKey++;
        else if (colorKey == KeyColor.Green) greenKey++;
        else blueKey++;
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

    public void PauseGame()
    {
        Debug.Log("Game Paused");
        Time.timeScale = 0f;
        gamePaused = true;
    }

    public void ResumeGame()
    {
        Debug.Log("Game Resumed");
        Time.timeScale = 1f;
        gamePaused = false;
    }

    void PauseCheck()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePaused) ResumeGame();
            else PauseGame();
        }
    }

    private void Update()
    {
        PauseCheck();
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
