using UnityEngine;

public class Lock : MonoBehaviour
{
    public Door[] doors;
    public KeyColor myColor;
    private bool unlocked;
    [SerializeField] private bool canOpen = false;
    Animator key;

    private void Start()
    {
        key = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            canOpen = true;
            Debug.Log($"Door canOpen={canOpen}");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canOpen = false;
            Debug.Log($"Door canOpen={canOpen}");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canOpen && !unlocked)
        {
            key.SetBool("useKey", CheckKey());
        }
    }

    public void OpenDoors()
    {
        foreach (Door d in doors)
        {
            d.OpenDoor();
        }
    }

    public bool CheckKey()
    {
        if(GameManager.gameManager.redKey>0 && myColor==KeyColor.Red)
        {
            GameManager.gameManager.redKey--;
            unlocked = true;
            return true;
        }
        if (GameManager.gameManager.greenKey > 0 && myColor == KeyColor.Green)
        {
            GameManager.gameManager.greenKey--;
            unlocked = true;
            return true;
        }
        if (GameManager.gameManager.blueKey > 0 && myColor == KeyColor.Blue)
        {
            GameManager.gameManager.blueKey--;
            unlocked = true;
            return true;
        }
        Debug.Log("You don't have a key!");
        return false;
    }
}
