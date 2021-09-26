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
    private bool topRow;
    private bool middleRow;
    private bool bottomRow;
    private bool firstCol;
    private bool middleCol;
    private bool lastCol;
    enum Position { TopLeft, TopMiddle, TopRight, MiddleLeft, MiddleMiddle, MiddleRight, BottomLeft, BottomMiddle, BottomRight };
    [SerializeField] private GameObject level1;
    [SerializeField] private GameObject[] mapTiles;
    // Start is called before the first frame update
    void Start()
    {
        Position pos;
        Destroy(level1);
        int height = levelMap.GetLength(0);
        int width = levelMap.GetLength(1);
        topLeftCorner = new Vector3(width * -1.0f + 0.5f, height - 0.5f, 1.0f);
        pos = Position.TopLeft;
        for (int i = 0; i < height; i++)
        {
            if (i == height - 1) pos = Position.BottomLeft;
            for (int j = 0; j < width; j++)
            {
                if (j == width - 1)
                {
                    if (pos == Position.TopMiddle) pos = Position.TopRight;
                    else if (pos == Position.MiddleMiddle) pos = Position.MiddleRight;
                    else if (pos == Position.BottomMiddle) pos = Position.BottomRight;

                }
                GenerateTile(levelMap[i, j], j, i, pos);
                if (pos == Position.TopLeft) pos = Position.TopMiddle;
                else if (pos == Position.MiddleLeft) pos = Position.MiddleMiddle;
                else if (pos == Position.BottomLeft) pos = Position.BottomMiddle;
                
            }
            pos = Position.MiddleLeft;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

 

    void GenerateTile(int type, int x, int y, Position pos)
    {
        if (type == 0) return;
        Instantiate(mapTiles[type - 1], topLeftCorner + new Vector3(x, -y, 0), RotateTile(type, x, y, pos));
    }

    Quaternion RotateTile(int type, int x, int y, Position pos)
    {
        if (pos == Position.TopLeft)
        {
            return Quaternion.identity;
        }
        if (pos == Position.TopMiddle)
        {
            return Quaternion.identity;
        }
        if (pos == Position.TopRight)
        {
            return Quaternion.identity;
        }
        if (pos == Position.MiddleLeft)
        {
            return Quaternion.identity;
        }
        if (pos == Position.MiddleMiddle)
        {
            return Quaternion.identity;
        }
        if (pos == Position.MiddleRight)
        {
            return Quaternion.identity;
        }
        if (pos == Position.BottomLeft)
        {
            return Quaternion.identity;
        }
        if (pos == Position.BottomMiddle)
        {
            return Quaternion.identity;
        }
        if (pos == Position.BottomRight)
        {
            return Quaternion.identity;
        }
        return Quaternion.identity;
    }
}
