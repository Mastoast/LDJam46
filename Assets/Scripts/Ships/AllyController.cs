﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyController : ShipController
{
    public GameObject breach;
    public GameObject fire;
    public float hullPoints = 100f;
    public float damageAmount = 10f;

    // Start is called before the first frame update
    void Start()
    {
        target = new GameObject();
        target.SetActive(true);
        target.transform.position = new Vector3(100, 50, 0);
        pilot = new AllyPilot();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.frameCount%(60*8) == 1)
        {
            target.transform.position = new Vector3(
                Random.Range(-2000, 2000),
                Random.Range(-2000, 2000),
                Random.Range(-2000, 2000)
            );
        }
    }

    void FixedUpdate()
    {
        GetDecision();
        Move();
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
        hullPoints -= damageAmount;
    }

    public void RepairedPart()
    {
        hullPoints += damageAmount;
    }

}
