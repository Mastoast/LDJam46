using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    public float speed = 10.0f;
    public float lifetime = 10.0f;

    private float spawnTime;

    private Rigidbody rb;
    private Collider collider;
    private AudioSource bong;
    private LineRenderer line;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
        bong = GetComponentInChildren<AudioSource>();
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
        if (!bong.isPlaying)
        {
            // Hide visual
            line.enabled = false;
            collider.enabled = false;

            // Play dead sound
            bong.Play();
            Destroy(gameObject, bong.clip.length);
        }
    }

}
