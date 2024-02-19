using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundContoller : MonoBehaviour
{

    public AudioClip[] sounds;

    private AudioSource audioSource => GetComponent<AudioSource>();
    public void PlaySound(AudioClip clip, float volume = 1f, float p1 = 0.85f, float p2 = 1.2f)
    {
        audioSource.pitch = Random.Range(p1, p2);
        audioSource.PlayOneShot(clip, volume);
    }


}
