using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyController : ShipController
{
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        target = new GameObject();
        target.SetActive(true);
        target.transform.position = new Vector3(100, 50, 0);
        pilot = new AllyPilot();
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
