using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    //PickUpPanel
    public Text timeText;
    public Text crystalText;
    public Text redKeysText;
    public Text greenKeysText;
    public Text blueKeysText;
    public Image snowFlake;

    //InfoPanel
    public GameObject infoPanel;
    public Text infoText;
    public Text reloadText;

    //InGamePanel
    public Text inGameText;

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
        snowFlake.enabled = false;
        timeText.text = timeToEnd.ToString();
        crystalText.text = points.ToString();
        redKeysText.text = redKey.ToString();
        greenKeysText.text = greenKey.ToString();
        blueKeysText.text = blueKey.ToString();
        infoPanel.SetActive(false);
        infoText.text = "Paused";
        reloadText.text = "";
        inGameText.text = "";
    }

    public void AddTime(int time)
    {
        timeToEnd += time;
        timeText.text = timeToEnd.ToString();
    }

    public void AddPoints(int p)
    {
        points += p;
        crystalText.text = points.ToString();
    }

    public void FreezeTime(int freezeTime)
    {
        snowFlake.enabled = true;
        CancelInvoke("Stopper");
        InvokeRepeating("Stopper", freezeTime, 1f);
    }


    public void AddKey(KeyColor colorKey)
    {
        if (colorKey == KeyColor.Red) redKey++;
        else if (colorKey == KeyColor.Green) greenKey++;
        else blueKey++;

        redKeysText.text = redKey.ToString();
        greenKeysText.text = greenKey.ToString();
        blueKeysText.text = blueKey.ToString();
    }

    void Stopper()
    {
        timeToEnd--;
        timeText.text = timeToEnd.ToString();
        snowFlake.enabled = false;
        Debug.Log($"Time: {timeToEnd}s");
        if (timeToEnd <= 0)
        {
            EndGame();
            Time.timeScale = 0f;
        }
    }

    public void PauseGame()
    {
        infoPanel.SetActive(true);
        Debug.Log("Game Paused");
        Time.timeScale = 0f;
        gamePaused = true;
    }

    public void ResumeGame()
    {
        infoPanel.SetActive(false);
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
        infoPanel.SetActive(true);
        CancelInvoke("Stopper");
        if (win)
        {
            Debug.Log("You Win!!! Reload?");
            infoText.text = "You Win!!!";
        }
        else
        {
            Debug.Log("You Lose!!! Reload?");
            infoText.text = "You Lose!!!";
        }
        reloadText.text = "Reload?";
    }
}
