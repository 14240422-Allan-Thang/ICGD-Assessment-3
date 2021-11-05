using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentController : MonoBehaviour
{
    public enum Direction { Up, Left, Down, Right};
    private PacMap.Direction lastInput;
    private PacMap.Direction currentInput;
    public Tweener tweener;
    public Animator animator;
    public ParticleSystem dust;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            lastInput = PacMap.Direction.Up;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            lastInput = PacMap.Direction.Left;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            lastInput = PacMap.Direction.Down;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            lastInput = PacMap.Direction.Right;
        }
        //check lastInput
        //if moveable
        if (!tweener.TweenExists(gameObject.transform))
        {
            if (PacMap.Validate(lastInput))
            {
                currentInput = lastInput;
                //move in direction
                animator.SetBool("Is Moving", true);
                moveInDirection(currentInput);
                PacMap.UpdatePacPosition(currentInput);
            }
            //if not
            //check currentInput
            //if moveable
            else if (PacMap.Validate(currentInput))
            {
                //move in currentInput direction
                animator.SetBool("Is Moving", true);
                moveInDirection(currentInput);
                PacMap.UpdatePacPosition(currentInput);
            }
            else animator.SetBool("Is Moving", false);
            //if not
            //do nothing
        }
    }

    private void moveInDirection(PacMap.Direction direction)
    {
        CreateDust();
        if (direction == PacMap.Direction.Up)
        {
            SetRotation(180);
            tweener.AddTween(gameObject.transform, gameObject.transform.position, gameObject.transform.position + new Vector3(0, 1, 0), 0.3f);
        }
        else if (direction == PacMap.Direction.Left)
        {
            SetRotation(-90);
            tweener.AddTween(gameObject.transform, gameObject.transform.position, gameObject.transform.position + new Vector3(-1, 0, 0), 0.3f);
        }
        else if (direction == PacMap.Direction.Down)
        {
            SetRotation(0);
            tweener.AddTween(gameObject.transform, gameObject.transform.position, gameObject.transform.position + new Vector3(0, -1, 0), 0.3f);
        }
        else if (direction == PacMap.Direction.Right)
        {
            SetRotation(90);
            tweener.AddTween(gameObject.transform, gameObject.transform.position, gameObject.transform.position + new Vector3(1, 0, 0), 0.3f);
        }
    }

    private void SetRotation(int zRotation)
    {
        gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, zRotation));
    }

    private void CreateDust()
    {
        dust.Play();
        
    }
}