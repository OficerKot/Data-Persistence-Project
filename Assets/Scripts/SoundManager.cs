using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        instance = this;
    }
    private AudioSource source;
    public AudioClip ballSound;
    public AudioClip looseSound;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }
    public void PlayBallSound()
    {
        source.PlayOneShot(ballSound);
    }

    public void PlayLooseSound()
    {
        source.PlayOneShot(looseSound);
    }
}
