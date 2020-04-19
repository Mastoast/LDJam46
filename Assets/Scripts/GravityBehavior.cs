using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBehavior : MonoBehaviour
{
    public float lerpSpeed = 10f;
    public float gravity = 10f;
    private bool isGrounded;
    public float deltaGround = 0.2f;

    private Vector3 surfaceNormal;
    private Vector3 myNormal;
    private float distGround;

    private Transform myTransform;
    public Collider PlatformCollider;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        myNormal = transform.up;
        myTransform = transform;
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        distGround = PlatformCollider.bounds.extents.y - PlatformCollider.bounds.center.y;
    }

    private void FixedUpdate()
    {
        rb.AddForce(-gravity * rb.mass * myNormal);
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray;
        RaycastHit hit;


        ray = new Ray(myTransform.position, -myNormal);
        if (Physics.Raycast(ray, out hit))
        {
            isGrounded = hit.distance <= distGround + deltaGround;
            surfaceNormal = hit.normal;
        }
        else
        {
            isGrounded = false;
            surfaceNormal = Vector3.up;
        }

        myNormal = Vector3.Lerp(myNormal, surfaceNormal, lerpSpeed * Time.deltaTime);

        Vector3 myForward = Vector3.Cross(myTransform.right, myNormal);

        Quaternion targetRot = Quaternion.LookRotation(myForward, myNormal);
        myTransform.rotation = Quaternion.Lerp(myTransform.rotation, targetRot, lerpSpeed * Time.deltaTime);

    }
}
