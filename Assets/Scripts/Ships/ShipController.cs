using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public float movementSpeed = 250.0f;
    public float rotationSpeed = 0.5f;
    public Pilot pilot;

    protected Vector3 velocity;
    protected GameObject target;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        GetDecision();
        Move();
    }

    public void GetDecision()
    {
        // Get pilot decision
        if (pilot != null && target.activeSelf)
        {
            // Handle rotation
            Vector3 addAngle = pilot.GetRotationDecision(transform, target.transform) * (Time.fixedDeltaTime * rotationSpeed);
            transform.forward += addAngle;

            // Handle velocity
            Vector3 addPosition = transform.forward;
            Vector3 addSpeed = pilot.GetVelocityDecision(transform, target.transform);
            addPosition = new Vector3(addPosition.x * addSpeed.x, addPosition.y * addSpeed.y, addPosition.z * addSpeed.z);
            velocity = addPosition * (Time.fixedDeltaTime * movementSpeed);
        }
    }

    public void Move()
    {
        transform.position += velocity;
    }
}
