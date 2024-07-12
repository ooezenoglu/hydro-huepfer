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

        private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            Debug.LogError("AudioSource component is missing from " + gameObject.name);
        }
    }

    public void StartGrowling()
    {
        if (audioSource != null && growl != null)
        {
            audioSource.clip = growl;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    public void StopGrowling()
    {     
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}
