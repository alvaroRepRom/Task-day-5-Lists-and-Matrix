using System.Collections.Generic;
using UnityEngine;

public class Spwaner : MonoBehaviour
{
    [SerializeField] private List<Pooling> pools;
    [SerializeField] private float uncertaintyRadius = 0.5f;
    [SerializeField] private Vector2 spawnAreaSemiDimensions = new Vector2(18f, 9f);

    private float timeToSpawn = 2f;
    private float timer = 0f;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeToSpawn)
        {
            timer = 0f;
            SpawnFood();
        }
    }
    Vector3 spawnPos;
    public void SpawnFood()
    {
        spawnPos = transform.position + RandomPosition();
        Ray ray = new Ray(spawnPos, Vector3.up);
        if(!Physics.SphereCast(ray, uncertaintyRadius, uncertaintyRadius))
        {
            int index = Random.Range(0, pools.Count);
            GameObject clone = pools[index].GetFrom();
            clone.transform.position = spawnPos;
            clone.transform.parent = transform;
        }
    }

    private Vector3 RandomPosition()
    {
        float x = Random.Range(-spawnAreaSemiDimensions.x, spawnAreaSemiDimensions.x);
        float z = Random.Range(-spawnAreaSemiDimensions.y, spawnAreaSemiDimensions.y);
        return new Vector3(x, 0, z);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(spawnPos, uncertaintyRadius);
    }
}
