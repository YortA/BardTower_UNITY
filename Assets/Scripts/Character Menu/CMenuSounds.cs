using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMenuSounds : MonoBehaviour
{
    public AudioClip CMainQSound;
    public AudioClip CMainZSound;
    public AudioClip CSpellQSound, CSpellWSound, CSpellESound, CSpellRSound;
    public AudioClip CSpellExecute; // "A" to exectue spell in spell menu
    public AudioClip CSpellExeFail; // "A" fails to execute (not enough notes)

    private AudioSource MenuAudio;

    // This is retarded, but this checks to see what state "A" is in. Will need to change this to an enum later.
    public static bool ASpellState = false;

    private void Start()
    {
        MenuAudio = GetComponent<AudioSource>();
    }

    public void QSound()
    {
        // Reference and check for state)
        if (CMenuScript.CurrentState == CMenuScript.MenuStates.CMain)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                MenuAudio.PlayOneShot(CMainQSound, 0.5F);
            }
        }
    }

    public void QSpellSound()
    {
        // Reference and check for state
        // Change to switch statement later (too lazy)
        if (CMenuScript.CurrentState == CMenuScript.MenuStates.CSpells)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                MenuAudio.PlayOneShot(CSpellQSound, 0.5F);
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                MenuAudio.PlayOneShot(CSpellWSound, 0.5F);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                MenuAudio.PlayOneShot(CSpellESound, 0.5F);
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                MenuAudio.PlayOneShot(CSpellRSound, 0.5F);
            }
        }
    }

    public void ZSound()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            MenuAudio.PlayOneShot(CMainZSound, 0.5F);
        }
    }

    public void ASound()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (ASpellState == true)
            {
                MenuAudio.PlayOneShot(CSpellExecute, 0.5F);
                ASpellState = false;
            }
            else
            {
                MenuAudio.PlayOneShot(CSpellExeFail, 0.5F);
            }
        }
    }

    void Update()
    {
        ASound();
        QSound();
        QSpellSound();
        ZSound();
    }

}
