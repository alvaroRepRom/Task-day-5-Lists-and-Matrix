using System.Collections.Generic;
using UnityEngine;

public class AmmuContainer : MonoBehaviour
{
    private Stack<GameObject> container = new();

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Food")
            if(!other.GetComponent<AmmoFood>().IsBullet)
                AddToContainer(other.gameObject);
    }

    private void AddToContainer(GameObject obj)
    {
        obj.SetActive(false);
        container.Push(obj);
    }

    public GameObject AmmuGet()
    {
        if (container.Count > 0)
            return container.Pop();
        return null;
    }
}
