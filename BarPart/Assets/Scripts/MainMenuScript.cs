using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : SoundContoller
{
    public AudioSource audioSource;
    public void PlaySoundStart()
    {
        PlaySound(sounds[0]);
        StartCoroutine(FadeOutSound(1.0f));
    }

    private IEnumerator FadeOutSound(float duration)
    {
        float startPitch = audioSource.pitch;
        float timer = 0.0f;

        while (timer < duration)
        {
            timer += Time.deltaTime;
            audioSource.pitch = Mathf.Lerp(startPitch, 0.0f, timer / duration);

            yield return null;
        }
        audioSource.pitch = 0.0f;
    }

}
