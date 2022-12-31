using UnityEngine;

public class CarMovement : MonoBehaviour
{
    [SerializeField] private string verticalAxis = "Vertical";
    [SerializeField] private string horizontalAxis = "Horizontal";
    [SerializeField] private float speed = 7f;
    [SerializeField] private float rotSpeed = 200f;

    private Rigidbody rb;
    private float horizontal, vertical;

    private void Awake() => rb = GetComponent<Rigidbody>();
    private void Update()
    {
        Inputs();
        Turn();        
    }
    private void FixedUpdate() => Move();
    private void Inputs()
    {
        horizontal = Input.GetAxis(horizontalAxis);
        vertical = Input.GetAxis(verticalAxis);
    }
    private void Move() => rb.MovePosition(rb.position + vertical * speed * Time.deltaTime * transform.forward);
    private void Turn() => transform.Rotate(horizontal * rotSpeed * Time.deltaTime * Vector3.up);
}
