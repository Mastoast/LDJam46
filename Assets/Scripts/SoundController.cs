using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    private AudioSource source;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!source.isPlaying)
        {
            GameObject.Destroy(gameObject);
        }
    }

    public void PlayClip(AudioClip clip)
    {
        source.clip = clip;
        source.pitch = Random.Range(0.9f, 1.1f);
        source.Play();
    }
}
