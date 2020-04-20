using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowBidule : Tutorial
{
    public GameObject bidule;
    public Camera cameraBidule;
    public Camera cameraPlayer;
    public PlayerMovement pm;
    public Canvas canvas;
    private float startTime;
    private bool justStarted = true;

        
    public override void checkIfHappening()
    {
        if (justStarted)
        {
            pm.enabled = false;
            canvas.enabled = false;
            bidule.SetActive(true);

            cameraPlayer.enabled = false;
            cameraBidule.enabled = true;

            startTime = Time.time;
            justStarted = false;
        }
        if(Time.time - startTime > 5)
        {
            cameraBidule.enabled = false;
            cameraPlayer.enabled = true;
            pm.enabled = true;
            canvas.enabled = true;
            TutorialManager.Instance.completedTutorial();
        }
    }
}
