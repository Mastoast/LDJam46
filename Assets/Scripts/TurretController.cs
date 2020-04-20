using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    public LaserController laser;
    
    private MeshCollider shipCollider;
    private AudioSource source;

    bool _justShot = false;

    void Start()
    {
        source = GetComponent<AudioSource>();
        shipCollider = GameObject.FindGameObjectWithTag("Ship").GetComponentInChildren<MeshCollider>();
    }

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
            if (hit.collider == shipCollider)
            {
                if (!_justShot)
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
                    StartCoroutine(Shoot());

                }
                else
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            }

    }

    IEnumerator Shoot()
    {
        _justShot = true;
       
        LaserController clone = Instantiate(laser, transform.position, transform.rotation);

        source.pitch = Random.Range(0.85f, 1.15f);
        source.Play();
        
        yield return new WaitForSeconds(Random.Range(1.5f, 3.0f));

        _justShot = false;
    }
}
