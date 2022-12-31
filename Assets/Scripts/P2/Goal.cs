using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] private int numOfCars;
    private List<string> endPositions = new();
    private string carTag = "Car";

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != carTag) return;
        endPositions.Add(other.gameObject.name);
        if (endPositions.Count == numOfCars)
            PrintResult();
    }

    private void PrintResult()
    {
        for(int i = 0; i < endPositions.Count; i++)
            Debug.Log(i + 1 + "º: " + endPositions[i]);
    }
}
