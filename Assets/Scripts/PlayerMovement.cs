using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 15f;

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
        //moveDir = new Vector3(Input.GetAxisRaw("Horizontal");

        //Debug.Log(Input.GetAxis("Horizontal"));
    }

    void FixedUpdate()
    {
        if (canMove)
            rb.MovePosition(rb.position + transform.TransformDirection(moveDir) * speed * Time.fixedDeltaTime);
    }
}
