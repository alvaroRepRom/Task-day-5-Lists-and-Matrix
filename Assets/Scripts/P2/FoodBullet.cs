using UnityEngine;

public class FoodBullet : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    private const float timeToDestroy = 5f;
    private float timer = 0f;

    public Transform Target { get; set; }

    private void OnEnable() => timer = 0f;
    private void Update()
    {
        Timer();
        transform.LookAt(Target);
        transform.Translate(speed * Time.deltaTime * Vector3.forward);
    }

    private void Timer()
    {
        timer += Time.deltaTime;
        if(timer >= timeToDestroy)
            DestroyBullet();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == Target)
            DestroyBullet();
    }

    private void DestroyBullet() => gameObject.SetActive(false);
}
