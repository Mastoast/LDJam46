using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyController : ShipController
{
    public GameObject breach;
    public GameObject fire;

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

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Laser"))
        {
            Vector3 impactPoint = collision.GetContact(0).point;
            Quaternion impactAngle = Quaternion.identity;
            impactAngle.eulerAngles = collision.GetContact(0).normal;
            GameObject newImpact = Instantiate(breach, impactPoint, impactAngle);
            newImpact.transform.SetParent(transform);
            Debug.Log(newImpact.transform.position);
        }
    }

    public void CreateImpact()
    {

    }
}
