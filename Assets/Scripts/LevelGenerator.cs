using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    int[,] levelMap =
    { 
        { 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 7 }, 
        { 2, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 4 }, 
        { 2, 5, 3, 4, 4, 3, 5, 3, 4, 4, 4, 3, 5, 4 }, 
        { 2, 6, 4, 0, 0, 4, 5, 4, 0, 0, 0, 4, 5, 4 }, 
        { 2, 5, 3, 4, 4, 3, 5, 3, 4, 4, 4, 3, 5, 3 }, 
        { 2, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 }, 
        { 2, 5, 3, 4, 4, 3, 5, 3, 3, 5, 3, 4, 4, 4 }, 
        { 2, 5, 3, 4, 4, 3, 5, 4, 4, 5, 3, 4, 4, 3 }, 
        { 2, 5, 5, 5, 5, 5, 5, 4, 4, 5, 5, 5, 5, 4 }, 
        { 1, 2, 2, 2, 2, 1, 5, 4, 3, 4, 4, 3, 0, 4 }, 
        { 0, 0, 0, 0, 0, 2, 5, 4, 3, 4, 4, 3, 0, 3 }, 
        { 0, 0, 0, 0, 0, 2, 5, 4, 4, 0, 0, 0, 0, 0 }, 
        { 0, 0, 0, 0, 0, 2, 5, 4, 4, 0, 3, 4, 4, 0 }, 
        { 2, 2, 2, 2, 2, 1, 5, 3, 3, 0, 4, 0, 0, 0 }, 
        { 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 4, 0, 0, 0 }, 
    };
    private Vector3 topLeftCorner;

    [SerializeField] private GameObject level1;
    [SerializeField] private GameObject[] mapTiles;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(level1);
        int height = levelMap.GetLength(0);
        int width = levelMap.GetLength(1);
        topLeftCorner = new Vector3(width * -1.0f + 0.5f, height - 0.5f, 1.0f);
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                GenerateTile(levelMap[i, j], j, i);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateTile(int type, int x, int y)
    {
        if (type == 0) return;
        Instantiate(mapTiles[type - 1], topLeftCorner + new Vector3(x, -y, 0), Quaternion.identity);
    }
}
