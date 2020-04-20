using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : Tutorial
{
    public GameObject entireMesh;
    public GameObject armMesh;
    public Camera cameraPlayer;
    public Camera cameraRobot;
    public PlayerMovement pm;
    public Canvas canvas;
    private float startTime;
    private bool justStarted = true;

        
    public override void checkIfHappening()
    {
        if (justStarted)
        {
            cameraPlayer.enabled = false;
            cameraRobot.enabled = true;
            
            canvas.enabled = false;
            pm.enabled = false;
            armMesh.SetActive(false);
            entireMesh.SetActive(true);
            
            startTime = Time.time;
            justStarted = false;
        }
    }
}
