using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacMap : MonoBehaviour
{
    int[,] levelMap = {
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
    public static int[,] pacMap;
    private static int height;
    private static int width;
    public enum Direction { None, Up, Left, Down, Right};
    public static int pacPosX = 1;
    public static int pacPosY = 1;
    // Start is called before the first frame update
    void Start()
    {
        height = levelMap.GetLength(0);
        width = levelMap.GetLength(1);

        pacMap = new int[height * 2 - 1, width * 2];

        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                pacMap[i, j] = levelMap[i, j];
            }
        }
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                pacMap[i, width + j] = levelMap[i, (width - 1) - j];
            }
        }
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                pacMap[height + i - 1, j] = levelMap[(height - 1) - i, j];
            }
        }
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                pacMap[height + i - 1, width + j] = levelMap[(height - 1) - i, (width - 1) - j];
            }
        }
        for (int i = 0; i < pacMap.GetLength(0); i++)
        {
            for (int j = 0; j < pacMap.GetLength(1); j++)
            {
                int here = pacMap[i, j];
                pacMap[i, j] = (here == 0 || here == 5 || here == 6) ? 1 : 2;
                Debug.Log("(" + i + ", " + j + "): " + pacMap[i, j]);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static bool Validate(Direction direction)
    {
        if (direction == Direction.Up)
        {
            if (pacMap[pacPosY - 1, pacPosX] == 1)
            {
                return true;
            }
            else return false;
        }
        else if (direction == Direction.Left)
        {
            if (pacMap[pacPosY, pacPosX - 1] == 1)
            {
                return true;
            }
            else return false;
        }
        else if (direction == Direction.Down)
        {
            if (pacMap[pacPosY + 1, pacPosX] == 1)
            {
                return true;
            }
            else return false;
        }
        else if (direction == Direction.Right)
        {
            Debug.Log(pacMap[pacPosX + 1, pacPosX]);
            if (pacMap[pacPosY, pacPosX + 1] == 1)
            {
                return true;
            }
            else return false;
        }
        else return false;
    }

    public static void UpdatePacPosition(Direction direction)
    {
        if (direction == Direction.Up)
        {
            pacPosY--;
        }
        else if (direction == Direction.Left)
        {
            pacPosX--;
        }
        else if (direction == Direction.Down)
        {
            pacPosY++;
        }
        else if (direction == Direction.Right)
        {
            pacPosX++;
        }
        else return;
    }
}
