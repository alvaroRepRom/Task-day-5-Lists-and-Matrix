using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RaceStatus : MonoBehaviour
{
    [SerializeField] private int numOfCars = 5;
    [SerializeField] private float distanceBetweenCars = 6;
    private List<Ray> rays = new();
    private List<RaycastHit> cars = new();
    public Transform FirstCar { get; private set; }

    private void Start()
    {
        for (int i = 0; i < numOfCars; i++)
        {
            Vector3 rayOrigin = transform.position + Vector3.back * distanceBetweenCars * i;
            Ray ray = new Ray(rayOrigin, Vector3.right);
            rays.Add(ray);
        }
    }

    private void Update()
    {        
        foreach (Ray ray in rays)
        {
            Physics.Raycast(ray, out RaycastHit hit);
            Debug.DrawRay(ray.origin, ray.direction, Color.red);
            cars.Add(hit);            
        }
        FirstCar = cars.OrderByDescending(hit => hit.point.x).First().transform;
    }
}
