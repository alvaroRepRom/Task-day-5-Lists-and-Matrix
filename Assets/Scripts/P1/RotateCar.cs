using UnityEngine;

public class RotateCar : MonoBehaviour
{
    [SerializeField] private float speed = 200f;
    [SerializeField] private KeyCode leftKey = KeyCode.A;
    [SerializeField] private KeyCode rightKey = KeyCode.D;

    private void Update()
    {
        transform.Rotate(speed * RotationDirection() * Time.deltaTime * Vector3.up);
    }

    private int RotationDirection()
    {
        if (Input.GetKey(leftKey))
            return -1;
        else 
        if (Input.GetKey(rightKey))
            return 1;
        return 0;
    }
}
