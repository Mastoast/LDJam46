using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager : MonoBehaviour
{
    public AllyController ship;
    public AudioClip touchedHull;
    public AudioClip emitting;

    private AudioSource source;

    void Start()
    {
        // Hit sound
        source = GetComponent<AudioSource>();
        source.clip = touchedHull;
        source.loop = false;
        source.Play();

        // Ship reference
        ship = GetComponentInParent<AllyController>();
    }

    void Update()
    {
        if (source.clip != emitting && source.isPlaying)
        {
            source.clip = emitting;
            source.loop = true;
            source.Play();
        }
    }

    public void OnDestroy()
    {
        ship.RepairedPart();
    }
}
