using UnityEngine;

public class WantPizza : MonoBehaviour
{
    [SerializeField] private GameObject pizzaIndicator;

    private float timer = 0f;
    private float wantPizzaTime;
    private float minTime = 3f;
    private float maxTime = 6f;

    private void Start() => ChangeTime();
    private void Update()
    {
        if (pizzaIndicator.activeSelf) return;
        if (IsTimeUp())
            SwitchPizzaIndicator(true);
    }

    private void ChangeTime() => wantPizzaTime = Random.Range(minTime, maxTime);

    private bool IsTimeUp()
    {
        timer += Time.deltaTime;
        if (timer >= wantPizzaTime)
        {
            timer = 0f;
            ChangeTime();
            return true;
        }
        return false;
    }

    public void SwitchPizzaIndicator(bool switchOn) => pizzaIndicator.SetActive(switchOn);
}
