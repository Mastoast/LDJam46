using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public float movementSpeed = 1000.0f;
    public float rotationSpeed = 2.3f;
    public Pilot pilot;

    private Rigidbody rb;
    private GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        target = GameObject.FindGameObjectWithTag("Player");
        pilot = new EnemyPilot();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        // Get pilot decision
        if (target.activeSelf)
        {
            // Handle rotation
            Vector3 addAngle = pilot.GetRotationDecision(transform, target.transform) * (Time.fixedDeltaTime * rotationSpeed);
            transform.forward += addAngle;


            // Handle velocity
            Vector3 addPosition = rb.rotation * Vector3.forward;
            Vector3 addSpeed = pilot.GetVelocityDecision(transform, target.transform);
            addPosition = new Vector3(addPosition.x * addSpeed.x, addPosition.y * addSpeed.y, addPosition.z * addSpeed.z);
            rb.velocity = addPosition * (Time.fixedDeltaTime * movementSpeed);
        }
    }
}
