using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float autoDestroyTime;

    [SerializeField] private Pooling bulletPool;
    private float timer;

    private void OnEnable() => timer = 0f;
    private void Update()
    {
        Timer();
        transform.Translate(speed * Time.deltaTime * Vector3.forward);
    }
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<WantPizza>()?.SwitchPizzaIndicator(false);
        DestroyBullet();
    }

    private void Timer()
    {
        timer += Time.deltaTime;
        if (timer >= autoDestroyTime)
            DestroyBullet();
    }
    private void DestroyBullet() { gameObject.SetActive(false); }
    public void SetPool(Pooling pool) => bulletPool = pool;
}
