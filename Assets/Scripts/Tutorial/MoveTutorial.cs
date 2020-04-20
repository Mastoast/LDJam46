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
    private float startTime;
    private bool justFinished = true;

    public override void checkIfHappening()
    {
        if (justStarted)
        {

            GetComponent<AudioSource>().Play();
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
            if (justFinished)
            {
                GetComponent<AudioSource>().Stop();
                TutorialManager.Instance.actionFinished();
                justFinished = false;
                startTime = Time.time;
            }
            if(Time.time - startTime > 2)
            TutorialManager.Instance.completedTutorial();
        }
        
    }
}
