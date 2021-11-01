using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentController : MonoBehaviour
{
    public enum Direction { Up, Left, Down, Right };
    private Direction lastInput;
    private Direction currentInput;
    public Tweener tweener;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            lastInput = Direction.Up;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            lastInput = Direction.Left;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            lastInput = Direction.Down;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            lastInput = Direction.Right;
        }
        //check lastInput
        //if moveable
        currentInput = lastInput;
        //move in direction
        //if not
        //check currentInput
        //if moveable
        //move in currentInput direction
        //if not
        //do nothing
    }

    private void moveInDirection()
    {
        SetRotation(180);
        tweener.AddTween(gameObject.transform, gameObject.transform.position, gameObject.transform.position + new Vector3(0, 1, 0), 0.3f);
    }

    private void SetRotation(int zRotation)
    {
        gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, zRotation));
    }
}