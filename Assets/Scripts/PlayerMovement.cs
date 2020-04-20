using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 15f;
    public float maxDistanceFromShip = 200f;
    public GameObject attachedShip;
    public GameObject RespawnPoint;

    private Rigidbody rb;
    private Vector3 moveDir;

    public bool canMove = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;

        if(Vector3.Distance(this.transform.position, attachedShip.transform.position) >= maxDistanceFromShip)
        {
            Death();
        }
    }

    void FixedUpdate()
    {
        if (canMove)
            transform.position += transform.TransformDirection(moveDir) * speed * Time.fixedDeltaTime;
    }

    public void Death()
    {
        this.transform.position = RespawnPoint.transform.position;
    }
}
