using System.Collections;
using UnityEngine;

public class WantPizzaP4 : MonoBehaviour
{
    [SerializeField] private GameObject pizzaIcon;

    private float timeToWantPizza;
    private float timeWaiting = 0f;

    public float TimeWaiting { get { return timeWaiting; } }

    private void Start() => StartCoroutine(TimerFunc());
    private void Update() { WaitTime(); }

    private void WaitTime()
    {
        if (pizzaIcon.activeSelf)
            timeWaiting += Time.deltaTime;
    }

    private IEnumerator TimerFunc()
    {
        timeWaiting = 0f;
        timeToWantPizza = Random.Range(3f, 10f);
        WaitForSeconds waitSeconds = new(timeToWantPizza);
        yield return waitSeconds;
        pizzaIcon.SetActive(true);
    }

    public void PizzaDelivered()
    {
        pizzaIcon.SetActive(false);
        StartCoroutine(TimerFunc());
    }
}
