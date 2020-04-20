﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCreator : MonoBehaviour
{
    public GameObject breach;
    public GameObject fire;

    private AllyController ship;

    // Start is called before the first frame update
    void Start()
    {
        ship = GetComponentInParent<AllyController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Laser"))
        {
            Vector3 impactPoint = collision.GetContact(0).point;
            Quaternion impactAngle = Quaternion.identity;
            impactAngle.eulerAngles = collision.GetContact(0).normal;
            GameObject newImpact = Instantiate(breach, impactPoint, impactAngle);
            newImpact.transform.SetParent(transform);
            DamageToHull();
        }
    }

    public void CreateImpact()
    {

    }

    //Damage Manager
    public void DamageToHull()
    {
        ship.hullPoints -= ship.damageAmount;
    }
}