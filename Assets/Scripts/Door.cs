using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform close;
    public Transform open;
    public Transform door;

    public bool isOpen;
    public float speed;

    private void Start()
    {
        door.position = close.position;
    }

    public void OpenDoor()
    {
        isOpen = true;
    }

    private void Update()
    {
        if (isOpen && Vector3.Distance(door.position, open.position)>0.01f)
        {
            door.position = Vector3.MoveTowards(
                door.position, open.position, speed*Time.deltaTime);
        }
    }
}
