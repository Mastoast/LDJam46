using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowShip : Tutorial
{
    public Camera cameraRobot;
    public Camera cameraRear;
    private bool justStarted = true;
    // Start is called before the first frame update

    public override void checkIfHappening()
    {
        if(justStarted)
        {
            GetComponent<AudioSource>().Play();
            cameraRobot.enabled = false;
            cameraRear.enabled = true;
            justStarted = false;

        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            GetComponent<AudioSource>().Stop();
            TutorialManager.Instance.completedTutorial();
        }
    }
}
