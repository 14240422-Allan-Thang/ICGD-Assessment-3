using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    private AudioSource source;
    public AudioClip pacMoveSound;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetBool("Is Moving"))
        {
            if (!source.isPlaying)
            {
                source.PlayOneShot(pacMoveSound, 0.5f);
            }
        }
    }
}
