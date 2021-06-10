using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickArea : MonoBehaviour
{
    public GameObject cubeGrid;
    public int gridX = 10;
    public int gridZ = 10;
    public int gridY = 10;
    public bool showGrid = false;
    [HideInInspector]
    public List<GameObject> gridComponent = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        SpawnGrid();
    }

    void Update()
    {
        if (showGrid == true)
        {
            foreach (GameObject item in gridComponent)
            {
                item.GetComponent<MeshRenderer>().enabled = true;
            }
        }
        else
        {
            foreach (GameObject item in gridComponent)
            {
                item.GetComponent<MeshRenderer>().enabled = false;
            }
        }
    }

    private void SpawnGrid()
    {
        GameObject container = new GameObject();
        GameObject gridContainer = Instantiate(container, Vector3.zero, Quaternion.identity, this.transform);
        for (int x = 0; x < gridX; x++)
        {
            for (int z = 0; z < gridX; z++)
            {
                for (int y = 0; y < gridY; y++)
                {
                    Vector3 spawnPosition = new Vector3((x * LegoLogic.Grid.x) + gridX * -0.5f * LegoLogic.Grid.x, y * LegoLogic.Grid.y + LegoLogic.Grid.y * 0.5f, (z * LegoLogic.Grid.z) + gridZ * -0.5f * LegoLogic.Grid.z);
                    string name = x + "," + y + "," + z;
                    SpawnObject(spawnPosition, Quaternion.identity, gridContainer, name);
                }
            }
        }
    }

    private void SpawnObject(Vector3 spawnPos, Quaternion spawnRo, GameObject parentT, String name)
    {
        GameObject newObj = (GameObject)Instantiate(cubeGrid, spawnPos, spawnRo, parentT.transform);
        newObj.name = name;
        gridComponent.Add(newObj);
    }
}
