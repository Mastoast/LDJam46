using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTutorial : Tutorial
{
    public GameObject entireMesh;
    public GameObject armMesh;
    public Camera cameraRear;
    public Camera cameraPlayer;
    public PlayerMovement pm;
    public List<string> keysToPress = new List<string>();
    private bool justStarted = true;

    public override void checkIfHappening()
    {
        if (justStarted)
        {
            pm.enabled = true;
            cameraRear.enabled = false;
            cameraPlayer.enabled = true;
            entireMesh.SetActive(false);
            armMesh.SetActive(true);
            justStarted = false;
        }
        foreach(string s in keysToPress)
        {
            if (Input.inputString.Contains(s))
            {
                keysToPress.Remove(s);
                break;
            }
        }

        if(keysToPress.Count == 0)
        {
            TutorialManager.Instance.completedTutorial();
        }
        
    }
}
