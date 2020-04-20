using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    public LaserController laser;
    public MeshCollider shipCollider;

    bool _justShot = false;

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
        
        yield return new WaitForSeconds(0.5f);

        _justShot = false;
    }
}
