using System.Collections.Generic;
using UnityEngine;

public class AutoDeliver : MonoBehaviour
{
    [SerializeField] private Transform restaurant;
    [SerializeField] private List<Transform> destinationPoints;
    [SerializeField] private int pizzaCounter = 0;
    [SerializeField] private Transform rayStart;

    private float rayDistance = 3f;
    private float longestTime = 0f;
    private float speed = 8f;

    private void Update()
    {
        Transform target = LongestWait();
        if (target != null)
        {
            transform.LookAt(target);
            transform.Translate(speed * Time.deltaTime * Vector3.forward);
            DestinationArrived();
        }
    }

    private Transform LongestWait() 
    {
        Transform longestWaitTrans = null;
        foreach(Transform point in destinationPoints)
        {
            float currentTime = point.GetComponentInParent<WantPizzaP4>().TimeWaiting;
            if (currentTime > longestTime)
            {
                longestTime = currentTime;
                longestWaitTrans = pizzaCounter > 0 ? point : restaurant;
            }
        }
        return longestWaitTrans;
    }

    private void DestinationArrived()
    {
        if (Physics.Raycast(rayStart.position, rayStart.forward, out RaycastHit hit, rayDistance))
        {
            if (hit.collider.tag == "Restaurant")
                TakeAway();
            if (hit.collider.tag == "House")
                DeliverFood(hit.collider);
        }
    }

    private void TakeAway()
    {
        foreach(Transform trans in destinationPoints)
        {
            float timeWaiting = trans.GetComponent<WantPizzaP4>().TimeWaiting;
            if (timeWaiting > 0)
                pizzaCounter++;
        }
    }

    private void DeliverFood(Collider collider)
    {
        pizzaCounter--;
        longestTime = 0f;
        collider.GetComponent<WantPizzaP4>().PizzaDelivered();
    }
}
