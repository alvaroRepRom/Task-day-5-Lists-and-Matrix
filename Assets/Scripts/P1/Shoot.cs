using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private Pooling pizzaPool;
    [SerializeField] private KeyCode shootKey = KeyCode.Space;

    private void Update()
    {
        if (Input.GetKeyDown(shootKey))
            Shooting();
    }

    private void Shooting()
    {
        GameObject pizzaObj = pizzaPool.GetFrom();
        pizzaObj.transform.position = transform.position;
        pizzaObj.transform.rotation = transform.rotation;
    }
}
