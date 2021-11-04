using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryController : MonoBehaviour
{
    public Tweener tweener;
    public GameObject spawn;
    public GameObject cherry;
    private Vector3 endPos;
    private enum Move { Left, Right, Up, Down};
    private Move currentMove;
    private float startX;
    private float startY;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnCherry", 0, 10);
    }

    // Update is called once per frame
    void Update()
    {
        DestroyCherry();
    }

    private void SpawnCherry()
    {
        RandomiseCherry();
        cherry = Instantiate(spawn, new Vector3(startX, startY, 0f), Quaternion.identity);
        MoveCherry();
    }

    private void DestroyCherry()
    {
        if (cherry != null)
        {
            if (cherry.transform.position == endPos)
            {
                Destroy(cherry);
            }
        }
    }

    private void MoveCherry()
    {
        if (!tweener.TweenExists(cherry.transform))
        {
            endPos = cherry.transform.position * -1f;
            float dist = Vector3.Distance(cherry.transform.position, endPos);
            tweener.AddTween(cherry.transform, cherry.transform.position, endPos, dist * 0.1f);
        }
    }

    private void RandomiseCherry()
    {
        int choice = Random.Range(0, 0);
        currentMove = (Move)choice;
        if (currentMove == Move.Right)
        {
            startX = -27.5f;
            startY = Random.Range(-17f, 17f);
        }
        else if (currentMove == Move.Left)
        {
            startX = 27.5f;
            startY = Random.Range(-17f, 17f);
        }
        else if (currentMove == Move.Up)
        {
            startY = -17f;
            startX = Random.Range(-27.5f, 27.5f);
        }
        else if (currentMove == Move.Down)
        {
            startY = 17f;
            startX = Random.Range(-27.5f, 27.5f);
        }
    }
}
