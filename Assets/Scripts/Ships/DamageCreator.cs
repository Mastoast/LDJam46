using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCreator : MonoBehaviour
{
    public GameObject breach;
    public GameObject fire;

    private AllyController ship;

    void Start()
    {
        ship = GetComponentInParent<AllyController>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Laser"))
        {
            float r1 = Random.Range(0f, 1f);

            // 25% chance to create a fire
            if (r1 < 0.25f)
            {
                // Create damage
                Vector3 impactPoint = collision.GetContact(0).point;
                Quaternion impactAngle = Quaternion.identity;
                impactAngle.eulerAngles = collision.GetContact(0).normal;

                Instantiate(fire, impactPoint, impactAngle, ship.transform);

                // Damage
                DamageToHull();
            }
        }
    }

    //Damage Manager
    public void DamageToHull()
    {
        ship.hullPoints -= ship.damageAmount;
    }
}
