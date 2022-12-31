using UnityEngine;

public class ChangeGrid : MonoBehaviour
{
    public MyGrid MyGridGrid { set; get; }

    private void OnMouseUp()
    {
        Vector3Int pos = new Vector3Int((int)transform.position.x, (int)transform.position.y, 0);
        MyGridGrid.ChangeGrid(pos);
    }
}
