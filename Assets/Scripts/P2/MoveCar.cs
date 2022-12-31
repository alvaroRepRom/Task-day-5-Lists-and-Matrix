using UnityEngine;

public class MoveCar : MonoBehaviour
{
    private float speed;
    private float minSpeed = 2.5f;
    private float maxSpeed = 4f;
    private float speedReduction = 0.75f;
    private bool isFinished;

    private void Start() => speed = Random.Range(minSpeed, maxSpeed);

    private void Update()
    {
        if (isFinished) return;        
        transform.Translate(speed * Time.deltaTime * Vector3.forward);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Food")
            speed *= speedReduction;
        else 
        if (other.tag == "Goal")
            isFinished = true;
    }
}
