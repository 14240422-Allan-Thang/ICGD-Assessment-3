using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
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
    private Vector3 topLeftCorner;
    private GameObject[,] tiles;
    private int[,] fullMap;
    private int width;
    private int height;
    //private bool noBelow;
    enum Position { TopLeft, NoneAbove, NoneLeft, Free };
    private Position pos;
    [SerializeField] private GameObject level1;
    [SerializeField] private GameObject[] mapTiles;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(level1);

        height = levelMap.GetLength(0);
        width = levelMap.GetLength(1);

        fullMap = new int[height * 2 - 1, width * 2];

        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                fullMap[i, j] = levelMap[i, j];
            }
        }
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                fullMap[i, width + j] = levelMap[i, (width - 1) - j];
            }
        }
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                fullMap[height + i - 1, j] = levelMap[(height - 1) - i, j];
            }
        }
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                fullMap[height + i - 1, width + j] = levelMap[(height - 1) - i, (width - 1) - j];
            }
        }
        tiles = new GameObject[height * 2, width * 2];

        pos = Position.TopLeft;
        topLeftCorner = new Vector3(width * -1.0f + 0.5f, height - 0.5f, 1.0f);
        for (int i = 0; i < height * 2 - 1; i++)
        {
            for (int j = 0; j < width * 2; j++)
            {
                GenerateTile(fullMap[i, j], i, j, pos, tiles);
                if (pos == Position.TopLeft) pos = Position.NoneAbove;
                if (pos == Position.NoneLeft) pos = Position.Free;
            }
            pos = Position.NoneLeft;
            //if (i == height * 2 - 2) noBelow = true;
        }
    }
    // Update is called once per frame
    void Update()
    {

    }

    void GenerateTile(int type, int i, int j, Position pos, GameObject[,] tiles)
    {
        if (type == 0) return;
        tiles[i, j] = Instantiate(mapTiles[type - 1], topLeftCorner + new Vector3(j, -i, 0), RotateTile(type, i, j, pos, tiles));
    }

    Quaternion RotateTile(int type, int i, int j, Position pos, GameObject[,] tiles)
    {
        bool left;
        bool up;
        if (pos == Position.TopLeft)
        {
            return Quaternion.identity;
        }
        else if (pos == Position.NoneAbove)
        {
            if (type == 1)
            {
                left = CheckLeft(type, i, j);
                if (left) return Quaternion.Euler(new Vector3(0, 0, -90));
                else return Quaternion.identity;
            }
            else if (type == 2)
            {
                left = CheckLeft(type, i, j);
                if (left) return Quaternion.Euler(new Vector3(0, 0, 90));
                else return Quaternion.identity;
            }
            else if (type == 3)
            {
                left = CheckLeft(type, i, j);
                if (left) return Quaternion.Euler(new Vector3(0, 0, -90));
                else return Quaternion.identity;
            }
            else if (type == 4)
            {
                left = CheckLeft(type, i, j);
                if (left) return Quaternion.Euler(new Vector3(0, 0, 90));
                else return Quaternion.identity;
            }
            else
            {
                return Quaternion.identity;
            }
        }
        else if (pos == Position.NoneLeft)
        {
            if (type == 1)
            {
                up = CheckAbove(type, i, j);
                if (up) return Quaternion.Euler(new Vector3(0, 0, 90));
                else return Quaternion.identity;
            }
            else if (type == 2)
            {
                up = CheckAbove(type, i, j);
                if (up) return Quaternion.identity;
                else return Quaternion.Euler(new Vector3(0, 0, 90));
            }
            else if (type == 3)
            {
                up = CheckAbove(type, i, j);
                if (up) return Quaternion.Euler(new Vector3(0, 0, 90));
                else return Quaternion.identity;
            }
            else if (type == 4)
            {
                up = CheckAbove(type, i, j);
                if (up) return Quaternion.identity;
                else return Quaternion.Euler(new Vector3(0, 0, 90));
            }
            else
            {
                return Quaternion.Euler(new Vector3(0, 0, 90));
            }
        }
        else
        {
            if (type == 1)
            {
                up = CheckAbove(type, i, j);
                left = CheckLeft(type, i, j);
                if (up && left) return Quaternion.Euler(new Vector3(0, 0, 180));
                else if (up && !left) return Quaternion.Euler(new Vector3(0, 0, 90));
                else if (!up && left) return Quaternion.Euler(new Vector3(0, 0, -90));
                else return Quaternion.identity;
            }
            else if (type == 2)
            {
                left = CheckLeft(type, i, j);
                if (left) return Quaternion.Euler(new Vector3(0, 0, 90));
                else return Quaternion.identity;
            }
            else if (type == 3)
            {
                up = CheckAbove(type, i, j);
                left = CheckLeft(type, i, j);
                if (up && left) return Quaternion.Euler(new Vector3(0, 0, 180));
                else if (up && !left) return Quaternion.Euler(new Vector3(0, 0, 90));
                else if (!up && left) return Quaternion.Euler(new Vector3(0, 0, -90));
                else return Quaternion.identity;
            }
            else if (type == 4)
            {
                up = CheckAbove(type, i, j);
                if (up) return Quaternion.identity;
                else
                {
                    return Quaternion.Euler(new Vector3(0, 0, 90));

                }
            }
            else
            {
                type = 7;
                left = CheckLeft(type, i, j);
                up = CheckAbove(type, i, j);
                bool aboveIsInside = false;
                switch (fullMap[i - 1, j])
                {
                    case 3:
                        if (tiles[i - 1, j].transform.rotation == Quaternion.identity || tiles[i - 1, j].transform.rotation.eulerAngles.z == -90 || tiles[i - 1, j].transform.rotation.eulerAngles.z == 270) aboveIsInside = true; break;
                    case 4:
                        if (tiles[i - 1, j].transform.rotation == Quaternion.identity) aboveIsInside = true; break;
                    case 7:
                        if (tiles[i - 1, j].transform.rotation == Quaternion.identity) aboveIsInside = true; break;
                    default:
                        aboveIsInside = false; break;
                }
                if (!up) return Quaternion.identity;
                else if (!left) return Quaternion.Euler(new Vector3(0, 0, 90));
                else if (aboveIsInside)
                {
                    return Quaternion.Euler(new Vector3(0, 0, 180));
                }
                else return Quaternion.Euler(new Vector3(0, 0, -90));
            }
        }
    }

    bool CheckAbove(int type, int i, int j)
    {
        if (type == 1)
        {
            switch (fullMap[i - 1, j])
            {
                case 1:
                    if (tiles[i - 1, j].transform.rotation == Quaternion.identity || tiles[i - 1, j].transform.rotation.eulerAngles.z == -90 || tiles[i - 1, j].transform.rotation.eulerAngles.z == 270) return true; break;
                case 2:
                    if (tiles[i - 1, j].transform.rotation == Quaternion.identity) return true; break;
                case 7:
                    if (tiles[i - 1, j].transform.rotation.eulerAngles.z == 90 || tiles[i - 1, j].transform.rotation.eulerAngles.z == -90 || tiles[i - 1, j].transform.rotation.eulerAngles.z == 270) return true; break;
                default:
                    return false;
            }
        }
        else if (type == 2)
        {
            switch (fullMap[i - 1, j])
            {
                case 1:
                    if (tiles[i - 1, j].transform.rotation == Quaternion.identity || tiles[i - 1, j].transform.rotation.eulerAngles.z == -90 || tiles[i - 1, j].transform.rotation.eulerAngles.z == 270) return true; break;
                case 2:
                    if (tiles[i - 1, j].transform.rotation == Quaternion.identity) return true; break;
                case 7:
                    if (tiles[i - 1, j].transform.rotation.eulerAngles.z == 90 || tiles[i - 1, j].transform.rotation.eulerAngles.z == -90 || tiles[i - 1, j].transform.rotation.eulerAngles.z == 270) return true; break;
                default:
                    return false;
            }
        }
        else if (type == 3)
        {
            switch (fullMap[i - 1, j])
            {
                case 3:
                    if (tiles[i - 1, j].transform.rotation == Quaternion.identity || tiles[i - 1, j].transform.rotation.eulerAngles.z == -90 || tiles[i - 1, j].transform.rotation.eulerAngles.z == 270) return true; break;
                case 4:
                    if (tiles[i - 1, j].transform.rotation == Quaternion.identity) return true; break;
                case 7:
                    if (tiles[i - 1, j].transform.rotation == Quaternion.identity) return true; break;
                default:
                    return false;
            }
        }
        else if (type == 4)
        {
            switch (fullMap[i - 1, j])
            {
                case 3:
                    if (tiles[i - 1, j].transform.rotation == Quaternion.identity || tiles[i - 1, j].transform.rotation.eulerAngles.z == -90 || tiles[i - 1, j].transform.rotation.eulerAngles.z == 270) return true; break;
                case 4:
                    if (tiles[i - 1, j].transform.rotation == Quaternion.identity) return true; break;
                case 7:
                    if (tiles[i - 1, j].transform.rotation == Quaternion.identity) return true; break;
                default:
                    return false;

            }
        }
        else if (type == 7)
        {
            switch (fullMap[i - 1, j])
            {
                case 1:
                    if (tiles[i - 1, j].transform.rotation == Quaternion.identity || tiles[i - 1, j].transform.rotation.eulerAngles.z == -90 || tiles[i - 1, j].transform.rotation.eulerAngles.z == 270) return true; break;
                case 2:
                    if (tiles[i - 1, j].transform.rotation == Quaternion.identity) return true; break;
                case 3:
                    if (tiles[i - 1, j].transform.rotation == Quaternion.identity || tiles[i - 1, j].transform.rotation.eulerAngles.z == -90 || tiles[i - 1, j].transform.rotation.eulerAngles.z == 270) return true; break;
                case 4:
                    if (tiles[i - 1, j].transform.rotation == Quaternion.identity) return true; break;
                case 7:
                    if (tiles[i - 1, j].transform.rotation == Quaternion.identity || tiles[i - 1, j].transform.rotation.eulerAngles.z == -90 || tiles[i - 1, j].transform.rotation.eulerAngles.z == 90 || tiles[i - 1, j].transform.rotation.eulerAngles.z == 270) return true; break;
                default:
                    return false;

            }
        }
        return false;
    }
    bool CheckLeft(int type, int i, int j)
    {
        if (type == 1)
        {
            switch (fullMap[i, j - 1])
            {
                case 1:
                    if (tiles[i, j - 1].transform.rotation == Quaternion.identity || tiles[i, j - 1].transform.rotation.eulerAngles.z == 90) return true; break;
                case 2:
                    if (tiles[i, j - 1].transform.rotation.eulerAngles.z == 90) return true; break;
                case 7:
                    if (tiles[i, j - 1].transform.rotation == Quaternion.identity || tiles[i, j - 1].transform.rotation.eulerAngles.z == 180) return true; break;
                default:
                    return false;
            }
        }
        else if (type == 2)
        {
            switch (fullMap[i, j - 1])
            {
                case 1:
                    if (tiles[i, j - 1].transform.rotation == Quaternion.identity || tiles[i, j - 1].transform.rotation.eulerAngles.z == 90) return true; break;
                case 2:
                    if (tiles[i, j - 1].transform.rotation.eulerAngles.z == 90) return true; break;
                case 7:
                    if (tiles[i, j - 1].transform.rotation == Quaternion.identity || tiles[i, j - 1].transform.rotation.eulerAngles.z == 180) return true; break;
                default:
                    return false;
            }
        }
        else if (type == 3)
        {
            switch (fullMap[i, j - 1])
            {
                case 3:
                    if (tiles[i, j - 1].transform.rotation == Quaternion.identity || tiles[i, j - 1].transform.rotation.eulerAngles.z == 90) return true; break;
                case 4:
                    if (tiles[i, j - 1].transform.rotation.eulerAngles.z == 90) return true; break;
                case 7:
                    if (tiles[i, j - 1].transform.rotation.eulerAngles.z == 90) return true; break;
                default:
                    return false;
            }
        }
        else if (type == 4)
        {
            switch (fullMap[i, j - 1])
            {
                case 3:
                    if (tiles[i, j - 1].transform.rotation == Quaternion.identity || tiles[i, j - 1].transform.rotation.eulerAngles.z == 90) return true; break;
                case 4:
                    if (tiles[i, j - 1].transform.rotation.eulerAngles.z == 90) return true; break;
                case 7:
                    if (tiles[i, j - 1].transform.rotation.eulerAngles.z == 90) return true; break;
                default:
                    return false;

            }
        }
        else if (type == 7)
        {
            switch (fullMap[i, j - 1])
            {
                case 1:
                    if (tiles[i, j - 1].transform.rotation == Quaternion.identity || tiles[i, j - 1].transform.rotation.eulerAngles.z == 90) return true; break;
                case 2:
                    if (tiles[i, j - 1].transform.rotation.eulerAngles.z == 90) return true; break;
                case 3:
                    if (tiles[i, j - 1].transform.rotation == Quaternion.identity || tiles[i, j - 1].transform.rotation.eulerAngles.z == 90) return true; break;
                case 4:
                    if (tiles[i, j - 1].transform.rotation.eulerAngles.z == 90) return true; break;
                case 7:
                    if (tiles[i - 1, j].transform.rotation == Quaternion.identity || tiles[i - 1, j].transform.rotation.eulerAngles.z == -90 || tiles[i - 1, j].transform.rotation.eulerAngles.z == 90 || tiles[i - 1, j].transform.rotation.eulerAngles.z == 270) return true; break;
                default:
                    return false;
            }
        }
        return false;
    }
    //bool CheckBelow(int type, int i, int j)
    //{
    //    if (fullMap[i + 1, j] == 4) return true;
    //    return false;
    //}
}
