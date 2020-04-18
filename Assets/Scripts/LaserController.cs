using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    public float speed = 10.0f;

    private Rigidbody rigidbody;
    private AudioSource pew;
    private LineRenderer line;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        pew = GetComponentInChildren<AudioSource>();
        line = GetComponent<LineRenderer>();

        rigidbody.AddForce(transform.forward * speed);
    }

    // Update is called once per frame
    void Update()
    {
        
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
