using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowEnemy : Tutorial
{
    public GameObject enemy;
    public Camera cameraEnemy;
    public Camera cameraPlayer;
    public PlayerMovement pm;
    private float startTime;
    private bool justStarted = true;

        
    public override void checkIfHappening()
    {
        if (justStarted)
        {
            pm.enabled = false;
            enemy.SetActive(true);

            cameraPlayer.enabled = false;
            cameraEnemy.enabled = true;

            startTime = Time.time;
            justStarted = false;
        }
        if(Time.time - startTime > 2)
        {
            TutorialManager.Instance.completedTutorial();
        }
    }
}
