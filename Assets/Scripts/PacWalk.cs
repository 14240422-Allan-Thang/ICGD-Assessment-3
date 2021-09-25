using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacWalk : MonoBehaviour
{
    public Animator animatorController;
    private bool movable;
    
    // Start is called before the first frame update
    void Start()
    {
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        if (movable) { 
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                SetRotation(180);
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                SetRotation(-90);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                SetRotation(90);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                SetRotation(0);
            }
            // Force Death with Space
            if (Input.GetKeyDown(KeyCode.Space))
            {
                animatorController.SetBool("IsWalking", false);
                animatorController.SetTrigger("Die");
                movable = false;
            }
        }
        // Reset on Return to see animations again after death
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Reset();

        }
    }

    private void SetRotation(int zRotation)
    {
        gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, zRotation));
    }

    private void Reset()
    {
        animatorController.SetBool("IsWalking", true);
        SetRotation(0);
        movable = true;
        animatorController.SetTrigger("Reset");
    }
}
