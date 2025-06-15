using UnityEngine;

public class Pickup : MonoBehaviour
{
    public Vector3 rotationSpeed;
    public void Rotation()
    {
        transform.Rotate(new
            Vector3(
            rotationSpeed.x * Time.deltaTime,
            rotationSpeed.y * Time.deltaTime,
            rotationSpeed.z * Time.deltaTime));
    }

    public virtual void Picked()
    {
        Debug.Log("Pickup Collected");
        Destroy(this.gameObject);
    }

    

    public void Update()
    {
        Rotation();
    }
}
