using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowDie : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.tag == "Dead")
        {
            animator.SetTrigger("Die");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
