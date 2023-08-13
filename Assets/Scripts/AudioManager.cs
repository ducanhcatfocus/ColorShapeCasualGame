using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
   private static AudioManager instance;

    public static AudioManager Instance => instance;

    public AudioSource audioSource;

    public AudioClip GainPointSound;
    public AudioClip WrongSound;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySound()
    {
        audioSource.PlayOneShot(GainPointSound);
    }

    public void PlayWrongSound()
    {
        audioSource.PlayOneShot(WrongSound);
    }
}
