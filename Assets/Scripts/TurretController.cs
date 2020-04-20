using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    public LaserController laser;
    public AudioClip[] laserClips;
    public SoundController sound;
    

    private MeshCollider shipCollider;

    bool _justShot = false;

    void Start()
    {
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

        // Create sound effect
        SoundController ssound = Instantiate(sound, transform.position, transform.rotation);
        ssound.PlayClip(laserClips[Random.Range(0, laserClips.Length - 1)]);

        yield return new WaitForSeconds(Random.Range(1.5f, 3.0f));

        _justShot = false;
    }
}
