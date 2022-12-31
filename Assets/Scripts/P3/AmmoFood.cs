using UnityEngine;

public class AmmoFood : MonoBehaviour
{
    private float speed = 10f;
    private float rotRpeed = 100f;

    private float timeToDeactivate = 3f;
    private float timer = 0f;

    public bool IsBullet { get; set; }

    private void OnEnable()
    {
        IsBullet = false;
        timer = 0f;
    }

    private void Update()
    {
        if (IsBullet) Bullet();
        else Wait();
    }

    private void Bullet()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.forward);
        timer += Time.deltaTime;
        if (timer >= timeToDeactivate)
            gameObject.SetActive(false);
    }
    private void Wait() => transform.Rotate(rotRpeed * Time.deltaTime * transform.up);
}
