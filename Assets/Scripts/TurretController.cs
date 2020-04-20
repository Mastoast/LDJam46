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
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
            if (hit.collider == shipCollider)
                if (!_justShot)
                    StartCoroutine(Shoot());
    }

    IEnumerator Shoot()
    {
        _justShot = true;

        Debug.Log("Laser Spawn");
        LaserController clone = Instantiate(laser, transform.position, transform.rotation);

        yield return new WaitForSeconds(1);

        _justShot = false;
    }
}
