using System.Collections.Generic;
using UnityEngine;

public class MyGrid : MonoBehaviour
{
    [SerializeField] private GameObject pizza;
    [SerializeField] private GameObject burger;
    [SerializeField] private int rows, columns;

    private GameObject[,] myMatrix;

    private void Start() => MatrixCreator();
    private void MatrixCreator()
    {
        myMatrix = new GameObject[rows, columns];
        for (int i = 0; i < columns; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                int seed = Random.Range(0, 2);
                CreateObject(seed, i, j);
            }
        }
    }

    private void CreateObject(int seed, int i, int j)
    {
        myMatrix[j, i] = Instantiate(seed == 0 ? pizza : burger, new Vector3Int(i, j, 0), transform.rotation);
        myMatrix[j, i].GetComponent<ChangeGrid>().MyGridGrid = this;
    }    

    public void ChangeGrid(Vector3Int position)
    {
        foreach(Vector3Int pos in TilesToChange(position))
            ModifyObject(pos.x, pos.y);
    }

    private List<Vector3Int> TilesToChange(Vector3Int position)
    {
        List<Vector3Int> listOfChanges = new();
        listOfChanges.Add(position);                    // add click position to the list

        Vector3Int newPos = position + Vector3Int.up;
        if (myMatrix.GetLength(0) > newPos.y)
            listOfChanges.Add(newPos);                  // add up position to the list if exist in matrix

        newPos = position + Vector3Int.down;
        if (0 <= newPos.y)
            listOfChanges.Add(newPos);                  // add down position to the list if exist in matrix

        newPos = position + Vector3Int.right;
        if (myMatrix.GetLength(1) > newPos.x)
            listOfChanges.Add(newPos);                  // add right position to the list if exist in matrix

        newPos = position + Vector3Int.left;
        if (0 <= newPos.x)
            listOfChanges.Add(newPos);                  // add left position to the list if exist in matrix

        return listOfChanges;
    }

    private void ModifyObject(int i, int j)
    {
        Destroy(myMatrix[j, i].gameObject);
        myMatrix[j, i] = Instantiate(myMatrix[j, i].CompareTag(burger.tag) ? pizza : burger, new Vector3Int(i, j, 0), transform.rotation);
        myMatrix[j, i].GetComponent<ChangeGrid>().MyGridGrid = this;
    }
}
