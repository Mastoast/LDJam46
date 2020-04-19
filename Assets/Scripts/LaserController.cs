using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    public float speed = 10.0f;
    public float lifetime = 10.0f;

    private float spawnTime;

    private Rigidbody rb;
    private AudioSource pew;
    private LineRenderer line;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        pew = GetComponentInChildren<AudioSource>();
        line = GetComponent<LineRenderer>();

        rb.AddForce(transform.forward * speed);

        spawnTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        // Destroy if too far away
        if (Time.time - spawnTime > lifetime)
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (!pew.isPlaying)
        {
            // Create breach on starship

            // Hide visual
            line.enabled = false;

            // Play dead sound
            pew.Play();
            Destroy(gameObject, pew.clip.length);
        }
    }

}
