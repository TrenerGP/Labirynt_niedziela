using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float speed = 1f;
    CharacterController characterController;

    public Transform groundCheck;
    public LayerMask groundMask;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        PlayerMove();
    }

    private void PlayerMove()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;

        RaycastHit hit;
        if(Physics.Raycast(groundCheck.position,
            transform.TransformDirection(Vector3.down),
            out hit, 0.5f, groundMask))
        {
            string terrainType = hit.collider.gameObject.tag;
            switch(terrainType)
            {
                case "Speed":
                    speed = 20f;
                    //Debug.Log("Speed");
                    break;
                case "Slow":
                    speed = 5f;
                    //Debug.Log("Slow");
                    break;
                default:
                    speed = 10f;
                    //Debug.Log("Normal");
                    break;
            }
        }

        characterController.Move(move * speed * Time.deltaTime);
    }
}
