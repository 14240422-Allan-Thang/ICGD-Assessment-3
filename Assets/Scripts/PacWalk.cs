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
        
    }

    private void SetRotation(int zRotation)
    {
        gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, zRotation));
    }

    private void Reset()
    {
        SetRotation(0);
        gameObject.transform.position = new Vector3();
    }
}
