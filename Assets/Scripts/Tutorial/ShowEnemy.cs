using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowEnemy : Tutorial
{
    public GameObject enemy;
    public Camera cameraEnemy;
    public Camera cameraPlayer;
    public PlayerMovement pm;
    private bool justStarted = true;

        
    public override void checkIfHappening()
    {
        if (justStarted)
        {
            GetComponent<AudioSource>().Play();
            pm.canMove = false;
            enemy.SetActive(true);

            cameraPlayer.enabled = false;
            cameraEnemy.enabled = true;
            justStarted = false;
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            GetComponent<AudioSource>().Stop();
            TutorialManager.Instance.completedTutorial();
        }
    }
}
