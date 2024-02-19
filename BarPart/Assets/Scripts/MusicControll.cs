using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControll : MonoBehaviour
{

    public AudioClip[] clips;

    int clipID;

    AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!source.isPlaying)
        {
            clipID = Random.Range(0,clips.Length);
            source.clip = clips[clipID];
            source.Play();
        }
    }


}

