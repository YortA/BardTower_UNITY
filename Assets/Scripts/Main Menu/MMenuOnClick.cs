using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MMenuOnClick : MonoBehaviour
{
    private AudioSource MenuAudio;

    public AudioClip NewGameSound;

    private void Start()
    {
        MenuAudio = GetComponent<AudioSource>();
    }

    public void PlaySound()
    {
        MenuAudio.PlayOneShot(NewGameSound, 0.5F);
    }
}
