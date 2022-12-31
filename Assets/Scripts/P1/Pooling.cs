using System.Collections.Generic;
using UnityEngine;

public class Pooling : MonoBehaviour
{
    [SerializeField] private GameObject objPrefab;
    [SerializeField] private int poolSize;

    private List<GameObject> pool;

    private void Awake() => CreatePool();
    private void CreatePool()
    {
        pool = new();
        for (int i = 0; i < poolSize; i++)
            CreateObject();
    }

    private void CreateObject()
    {
        GameObject clone = Instantiate(objPrefab);
        clone.transform.parent = transform;
        clone.SetActive(false);
        pool.Add(clone);
    }

    public GameObject GetFrom()
    {
        GameObject pooled = pool.Find(obj => !obj.activeSelf);
        if (pooled == null)
        {
            CreateObject();
            pooled = pool[^1]; // Access first element from last
        }
        pooled.SetActive(true);
        return pooled;
    }
}
