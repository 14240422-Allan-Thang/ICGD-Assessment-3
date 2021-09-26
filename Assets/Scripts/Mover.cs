using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    private Tweener tweener;
    private Vector3 endPos;
    private Vector3 topLeft;
    private Vector3 topRight;
    private Vector3 bottomLeft;
    private Vector3 bottomRight;
    [SerializeField]
    private GameObject item;

    private void Awake()
    {
        topLeft = new Vector3(-12.5f, 13.5f, 0.0f);
        topRight = new Vector3(-7.5f, 13.5f, 0.0f);
        bottomLeft = new Vector3(-12.5f, 9.5f, 0.0f);
        bottomRight = new Vector3(-7.5f, 9.5f, 0.0f);
    }
    // Start is called before the first frame update
    void Start()
    {
        tweener = GetComponent<Tweener>();
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        if (item.transform.position == topRight)
        {
            endPos = bottomRight;
            SetRotation(0);
            tweener.AddTween(item.transform, item.transform.position, endPos, 1.5f);
        }
        else if (item.transform.position == bottomRight)
        {
            endPos = bottomLeft;
            SetRotation(-90);
            tweener.AddTween(item.transform, item.transform.position, endPos, 1.5f);
        }
        else if (item.transform.position == bottomLeft)
        {
            endPos = topLeft;
            SetRotation(180);
            tweener.AddTween(item.transform, item.transform.position, endPos, 1.5f);
        }
        else if (item.transform.position == topLeft)
        {
            endPos = topRight;
            SetRotation(90);
            tweener.AddTween(item.transform, item.transform.position, endPos, 1.5f);
        }
    }

    private void SetRotation(int zRotation)
    {
        item.transform.rotation = Quaternion.Euler(new Vector3(0, 0, zRotation));
    }

    private void Reset()
    {
        SetRotation(0);
        gameObject.transform.position = new Vector3(-7.5f, 13.5f, 0.0f);
    }
}
