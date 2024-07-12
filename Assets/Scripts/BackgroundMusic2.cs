using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic2 : MonoBehaviour
{    

    public static BackgroundMusic2 Instance;

    // Audio
    public AudioClip growl;
    private AudioSource audioSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartGrowling()
    {
        audioSource = GetComponent<AudioSource>();

        audioSource.clip = growl;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void StopGrowling()
    {     
        audioSource.Stop();
    }
}
