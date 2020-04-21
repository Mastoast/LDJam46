using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowRefill : Tutorial
{
    public Camera cameraRefill;
    public Camera cameraPlayer;
    public PlayerMovement pm;
    public Canvas canvas;
    private bool justStarted = true;

        
    public override void checkIfHappening()
    {
        if (justStarted)
        {
            GetComponent<AudioSource>().Play();
            pm.canMove = false;
            canvas.enabled = false;

            cameraPlayer.enabled = false;
            cameraRefill.enabled = true;
            
            justStarted = false;
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            GetComponent<AudioSource>().Stop();
            cameraRefill.enabled = false;
            cameraPlayer.enabled = true;
            pm.canMove = true;
            canvas.enabled = true;
            TutorialManager.Instance.completedTutorial();
        }
    }
}
