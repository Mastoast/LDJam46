using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipExtinguisher : Tutorial
{
    public Camera cameraFire;
    public Camera cameraPlayer;
    public PlayerMovement pm;
    public Canvas canvas;
    public List<string> keysToPress = new List<string>();
    private bool justStarted = true;

    public override void checkIfHappening()
    {
        if (justStarted)
        {
            canvas.enabled = true;
            pm.canMove = true;
            cameraFire.enabled = false;
            cameraPlayer.enabled = true;
            justStarted = false;
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            TutorialManager.Instance.completedTutorial();
        }        
    }
}
