using System.Collections.Generic;
using UnityEngine;

public class AutoShooting : MonoBehaviour
{
    [SerializeField] private List<Pooling> foodBullets;
    [SerializeField] private KeyCode key = KeyCode.Space;
    [SerializeField] private RaceStatus raceStatus;

    private int index = 0;
    private bool canShoot = true;
    private  const float cadenceTime = 1f;
    private float timer = 0f;

    private void Update()
    {
        if (canShoot)
        {
            if (Input.GetKey(key))
                Shoot();
        }
        else
            Timer();
    }

    private void Timer()
    {
        timer += Time.deltaTime;
        if (timer >= cadenceTime)
        {
            canShoot = true;
            timer = 0f;
        }
    }

    private void Shoot()
    {
        canShoot = false;
        GameObject bullet = foodBullets[index].GetFrom();
        bullet.transform.position = transform.position;
        bullet.GetComponent<FoodBullet>().Target = raceStatus.FirstCar;
        index++;
        if (index == foodBullets.Count)
            index = 0;
    }
}
