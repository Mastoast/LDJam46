using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowFire : Tutorial
{
    public Camera cameraEnemy;
    public Camera cameraFire;
    public GameObject fire;
    private float startTime;
    private bool justStarted = true;
        
    public override void checkIfHappening()
    {
        if (justStarted)
        {
            fire.SetActive(true);
            cameraEnemy.enabled = false;
            cameraFire.enabled = true;
            startTime = Time.time;
            justStarted = false;
        }
        if(Time.time - startTime > 2)
        {
            TutorialManager.Instance.completedTutorial();
        }
    }
}
