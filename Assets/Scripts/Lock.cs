using UnityEngine;

public class Lock : MonoBehaviour
{
    [SerializeField] private bool canOpen = false;

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
}
