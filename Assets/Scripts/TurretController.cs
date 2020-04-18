using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    public LaserController laser;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.renderedFrameCount % 300 == 1)
        {
            LaserController clone = Instantiate(laser, transform.position, transform.rotation);
        }
    }
}
