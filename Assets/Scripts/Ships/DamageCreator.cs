using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCreator : MonoBehaviour
{
    public GameObject fire;
    public AudioClip[] touchedHullSounds;
    public SoundController sound;

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

            // Get collision infos
            Vector3 impactPoint = collision.GetContact(0).point;
            Quaternion impactAngle = Quaternion.identity;
            impactAngle.eulerAngles = collision.GetContact(0).normal;

            // Create sound effect
            SoundController ssound = Instantiate(sound, impactPoint, impactAngle);
            ssound.PlayClip(touchedHullSounds[Random.Range(0, touchedHullSounds.Length - 1)]);

            // 25% chance to create a fire
            if (r1 < 0.25f)
            {
                // Create damage
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
