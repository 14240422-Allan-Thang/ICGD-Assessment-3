using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] clips;
    private bool introPlayed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!introPlayed)
        {
            GetComponent<AudioSource>().clip = clips[0];
            GetComponent<AudioSource>().Play();
            introPlayed = true;
        }
        if (introPlayed && !GetComponent<AudioSource>().isPlaying) 
        { 
            GetComponent<AudioSource>().clip = clips[1];
            GetComponent<AudioSource>().Play();
        }
    }
}
