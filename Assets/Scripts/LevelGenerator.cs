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
    private GameObject[][] tiles;
    enum Position { TopLeft, NoneAbove, NoneLeft, Free };
    private Position pos;
    [SerializeField] private GameObject level1;
    [SerializeField] private GameObject[] mapTiles;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(level1);
        int height = levelMap.GetLength(0);
        int width = levelMap.GetLength(1);
        topLeftCorner = new Vector3(width * -1.0f + 0.5f, height - 0.5f, 1.0f);
        pos = Position.TopLeft;
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                GenerateTile(levelMap[i, j], j, i, pos);
                if (pos == Position.TopLeft) pos = Position.NoneAbove;
                else if (pos == Position.NoneLeft) pos = Position.Free;
            }
            pos = Position.NoneLeft;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void GenerateTile(int type, int x, int y, Position pos)
    {
        if (type == 0) return;
        Debug.Log("Before Instantiate");
        tiles[x][y] = Instantiate(mapTiles[type - 1], topLeftCorner + new Vector3(x, -y, 0), RotateTile(type, x, y, pos));
        Debug.Log("After Instantiate");
    }

    Quaternion RotateTile(int type, int x, int y, Position pos)
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
                left = CheckLeft(type, x, y);
                if (left) return Quaternion.Euler(new Vector3(0, 0, -90));
                else return Quaternion.identity;
            }
            else if (type == 2)
            {
                left = CheckLeft(type, x, y);
                if (left) return Quaternion.Euler(new Vector3(0, 0, 90));
                else return Quaternion.identity;
            }
            else if (type == 3)
            {
                left = CheckLeft(type, x, y);
                if (left) return Quaternion.Euler(new Vector3(0, 0, -90));
                else return Quaternion.identity;
            }
            else if (type == 4)
            {
                left = CheckLeft(type, x, y);
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
                up = CheckAbove(type, x, y);
                if (up) return Quaternion.Euler(new Vector3(0, 0, 90));
                else return Quaternion.identity;
            }
            else if (type == 2)
            {
                up = CheckAbove(type, x, y);
                if (up) return Quaternion.identity;
                else return Quaternion.Euler(new Vector3(0, 0, 90));
            }
            else if (type == 3)
            {
                up = CheckAbove(type, x, y);
                if (up) return Quaternion.Euler(new Vector3(0, 0, 90));
                else return Quaternion.identity;
            }
            else if (type == 4)
            {
                up = CheckAbove(type, x, y);
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
                up = CheckAbove(type, x, y);
                left = CheckLeft(type, x, y);
                if (up && left) return Quaternion.Euler(new Vector3(0, 0, 180));
                else if (up && !left) return Quaternion.Euler(new Vector3(0, 0, 90));
                else if (!up && left) return Quaternion.Euler(new Vector3(0, 0, -90));
                else return Quaternion.identity;
            }
            else if (type == 2)
            {
                left = CheckLeft(type, x, y);
                if (left) return Quaternion.Euler(new Vector3(0, 0, -90));
                else return Quaternion.identity;
            }
            else if (type == 3)
            {
                up = CheckAbove(type, x, y);
                left = CheckLeft(type, x, y);
                if (up && left) return Quaternion.Euler(new Vector3(0, 0, 180));
                else if (up && !left) return Quaternion.Euler(new Vector3(0, 0, 90));
                else if (!up && left) return Quaternion.Euler(new Vector3(0, 0, -90));
                else return Quaternion.identity;
            }
            else if (type == 4)
            {
                left = CheckLeft(type, x, y);
                if (left) return Quaternion.Euler(new Vector3(0, 0, -90));
                else return Quaternion.identity;
            }
            else
            {
                type = 7;
                left = CheckLeft(type, x, y);
                up = CheckAbove(type, x, y);
                bool outsideCheck = false;
                switch (levelMap[x - 1, y])
                {
                    case 1:
                        if (tiles[x - 1][y].transform.rotation == Quaternion.identity || tiles[x - 1][y].transform.rotation.eulerAngles.z == -90) outsideCheck = true; break;
                    case 2:
                        if (tiles[x - 1][y].transform.rotation == Quaternion.identity) outsideCheck = true; break;
                    case 7:
                        if (tiles[x - 1][y].transform.rotation == Quaternion.identity || tiles[x - 1][y].transform.rotation.eulerAngles.z == 180) outsideCheck = true; break;
                    default:
                        outsideCheck = false; break;
                }
                if (!up) return Quaternion.identity;
                else if (!left) return Quaternion.Euler(new Vector3(0, 0, 90));
                else if (outsideCheck)
                {
                    return Quaternion.Euler(new Vector3(0, 0, -90));
                }
                else return Quaternion.Euler(new Vector3(0, 0, 180));


            }
        }
    }

    bool CheckAbove(int type, int x, int y)
    {
        if (type == 1)
        {
            switch (levelMap[x - 1, y])
            {
                case 1:
                    if (tiles[x - 1][y].transform.rotation == Quaternion.identity || tiles[x - 1][y].transform.rotation.eulerAngles.z == -90) return true; break;
                case 2:
                    return true;
                case 7:
                    if (tiles[x - 1][y].transform.rotation.eulerAngles.z == 90 || tiles[x - 1][y].transform.rotation.eulerAngles.z == -90) return true; break;
                default:
                    return false;
            }
        }
        else if (type == 2)
        {
            switch (levelMap[x - 1, y])
            {
                case 1:
                    if (tiles[x - 1][y].transform.rotation == Quaternion.identity || tiles[x - 1][y].transform.rotation.eulerAngles.z == -90) return true; break;
                case 2:
                    return true;
                case 7:
                    if (tiles[x - 1][y].transform.rotation.eulerAngles.z == 90 || tiles[x - 1][y].transform.rotation.eulerAngles.z == -90) return true; break;
                default:
                    return false;
            }
        }
        else if (type == 3)
        {
            switch (levelMap[x - 1, y])
            {
                case 3:
                    if (tiles[x - 1][y].transform.rotation == Quaternion.identity || tiles[x - 1][y].transform.rotation.eulerAngles.z == -90) return true; break;
                case 4:
                    if (tiles[x - 1][y].transform.rotation == Quaternion.identity) return true; break;
                case 7:
                    if (tiles[x - 1][y].transform.rotation == Quaternion.identity) return true; break;
                default:
                    return false;
            }
        }
        else if (type == 4)
        {
            switch (levelMap[x - 1, y])
            {
                case 3:
                    if (tiles[x - 1][y].transform.rotation == Quaternion.identity || tiles[x - 1][y].transform.rotation.eulerAngles.z == -90) return true; break;
                case 4:
                    if (tiles[x - 1][y].transform.rotation == Quaternion.identity) return true; break;
                case 7:
                    if (tiles[x - 1][y].transform.rotation == Quaternion.identity) return true; break;
                default:
                    return false;

            }
        }
        return false;
    }
    bool CheckLeft(int type, int x, int y)
    {
        if (type == 1)
        {
            switch (levelMap[x, y - 1])
            {
                case 1:
                    if (tiles[x][y - 1].transform.rotation == Quaternion.identity || tiles[x][y - 1].transform.rotation.eulerAngles.z == 90) return true; break;
                case 2:
                    return true;
                case 7:
                    if (tiles[x][y - 1].transform.rotation == Quaternion.identity || tiles[x][y - 1].transform.rotation.eulerAngles.z == 180) return true; break;
                default:
                    return false;
            }
        }
        else if (type == 2)
        {
            switch (levelMap[x, y - 1])
            {
                case 1:
                    if (tiles[x][y - 1].transform.rotation == Quaternion.identity || tiles[x][y - 1].transform.rotation.eulerAngles.z == 90) return true; break;
                case 2:
                    return true;
                case 7:
                    if (tiles[x][y - 1].transform.rotation == Quaternion.identity || tiles[x][y - 1].transform.rotation.eulerAngles.z == 180) return true; break;
                default:
                    return false;
            }
        }
        else if (type == 3)
        {
            switch (levelMap[x, y - 1])
            {
                case 3:
                    if (tiles[x][y - 1].transform.rotation == Quaternion.identity || tiles[x][y - 1].transform.rotation.eulerAngles.z == 90) return true; break;
                case 4:
                    if (tiles[x][y - 1].transform.rotation.eulerAngles.z == 90) return true; break;
                case 7:
                    if (tiles[x][y - 1].transform.rotation.eulerAngles.z == 90) return true; break;
                default:
                    return false;
            }
        }
        else if (type == 4)
        {
            switch (levelMap[x, y - 1])
            {
                case 3:
                    if (tiles[x][y - 1].transform.rotation == Quaternion.identity || tiles[x][y - 1].transform.rotation.eulerAngles.z == 90) return true; break;
                case 4:
                    if (tiles[x][y - 1].transform.rotation.eulerAngles.z == 90) return true; break;
                case 7:
                    if (tiles[x][y - 1].transform.rotation.eulerAngles.z == 90) return true; break;
                default:
                    return false;

            }
        }
        return false;
    }

    //bool CheckAbove(int type, int x, int y)
    //{
    //    if (type == 1)
    //    {
    //        if (levelMap[x - 1, y] == 2) return true;
    //    }
    //    else if (type == 2)
    //    {
    //        if (CheckTargetWithRotation(type, levelMap[x - 1, y], x, y)) return true;
    //    }
    //    else if (type == 3)
    //    {
    //        if (levelMap[x - 1, y] == *) return true;
    //    }
    //    else if (type == 4)
    //    {
    //        if (levelMap[x - 1, y] == *) return true;
    //    }
    //    else if (type == 7)
    //    {
    //        if (levelMap[x - 1, y] == *) return true;
    //    }
    //    return false;
    //}

    //bool CheckBelow(int type, int x, int y)
    //{
    //    if (type == 1)
    //    {
    //        if (levelMap[x - 1, y] == 2) return true;
    //    }
    //    else if (type == 2)
    //    {
    //        if (CheckTarget(type, levelMap[x - 1, y])) return true;
    //    }
    //    else if (type == 3)
    //    {
    //        if (levelMap[x - 1, y] == *) return true;
    //    }
    //    else if (type == 4)
    //    {
    //        if (levelMap[x - 1, y] == *) return true;
    //    }
    //    else if (type == 7)
    //    {
    //        if (levelMap[x - 1, y] == *) return true;
    //    }
    //    return false;
    //}

    //bool CheckTarget(int type, int target)
    //{
    //    if (type == 1)
    //    {
    //        if (target == 2) return true;
    //    }
    //    else if (type == 2)
    //    {
    //        switch (target)
    //        {
    //            case 1:
    //            case 2:
    //            case 7:
    //                return true;
    //        }
    //    }
    //    else if (type == 3)
    //    {
    //        switch(target)
    //        {
    //            case 
    //        }
    //        return false;
    //    }
    //    else if (type == 4)
    //    {
    //        return false;
    //    }
    //    else if (type == 7)
    //    {
    //        return false;
    //    }
    //}

    //bool CheckTargetWithRotation(int type, int target, int x, int y)
    //{
    //    if (type == 1)
    //    {
    //        if (target == 2) return true;
    //    }
    //    else if (type == 2)
    //    {
    //        switch (target)
    //        {
    //            case 1:
    //            case 2:
    //            case 7:
    //                return true;
    //        }
    //    }
    //    else if (type == 3)
    //    {
    //        switch (target)
    //        {
    //            case
    //        }
    //    }
    //    else if (type == 4)
    //    {
    //        return false;
    //    }
    //    else if (type == 7)
    //    {
    //        return false;
    //    }
    //    return false;
    //}
}
