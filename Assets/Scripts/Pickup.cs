using UnityEngine;

public class Pickup : MonoBehaviour
{
    public float rotationSpeed = 100;

    public virtual void Picked()
    {
        Debug.Log("Pickup Collected");
        Destroy(this.gameObject);
    }

    public void Rotation()
    {
        transform.Rotate(new 
            Vector3(rotationSpeed * Time.deltaTime, 0f, 0f));
    }

    public void Update()
    {
        Rotation();
    }
}
