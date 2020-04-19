using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : ShipController
{
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        target = GameObject.FindGameObjectWithTag("Ship");
        pilot = new EnemyPilot();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        GetDecision();
    }
}
