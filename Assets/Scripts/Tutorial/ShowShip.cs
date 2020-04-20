using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowShip : Tutorial
{
    public Camera cameraRobot;
    public Camera cameraRear;
    private float startTime;
    private bool justStarted = true;
    // Start is called before the first frame update

    public override void checkIfHappening()
    {
        if(justStarted)
        {
            cameraRobot.enabled = false;
            cameraRear.enabled = true;
            startTime = Time.time;
            justStarted = false;

        }
        if (Time.time - startTime > 2)
        {
            TutorialManager.Instance.completedTutorial();
        }
    }
}
