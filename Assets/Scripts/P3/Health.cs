using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private GameObject particles;
    [SerializeField] private int currentHealth = 5;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Food")
            if (other.GetComponent<AmmoFood>().IsBullet)
            {
                Damage();
                other.gameObject.SetActive(false);
            }
    }

    private void Damage()
    {
        currentHealth -= 1;
        particles.SetActive(true);
        if (currentHealth <= 0)
            gameObject.SetActive(false);
    }
}
