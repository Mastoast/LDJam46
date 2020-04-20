using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipSoulderTool : Tutorial
{
    public PlayerMovement pm;
    public Canvas canvas;
    private bool justStarted = true;

    public override void checkIfHappening()
    {
        if (justStarted)
        {
            canvas.enabled = true;
            pm.enabled = true;
            justStarted = false;
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            TutorialManager.Instance.completedTutorial();
        }        
    }
}
