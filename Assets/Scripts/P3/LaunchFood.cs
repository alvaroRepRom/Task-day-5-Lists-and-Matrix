using UnityEngine;

public class LaunchFood : MonoBehaviour
{
    [SerializeField] private Transform launchPos;
    [SerializeField] private AmmuContainer ammuContainer;
    [SerializeField] private KeyCode key = KeyCode.Space;

    private void Update()
    {
        if (Input.GetKeyDown(key))
            Launch();
    }

    private void Launch()
    {
        GameObject bullet = ammuContainer.AmmuGet();
        if (bullet != null)
        {
            bullet.SetActive(true);
            bullet.GetComponent<AmmoFood>().IsBullet = true;
            bullet.transform.position = launchPos.position;
            bullet.transform.rotation = launchPos.rotation;
        }
    }
}
