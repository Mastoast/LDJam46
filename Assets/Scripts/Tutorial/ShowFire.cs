using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowFire : Tutorial
{
    public Camera cameraEnemy;
    public Camera cameraFire;
    public GameObject fire;
    private bool justStarted = true;
        
    public override void checkIfHappening()
    {
        if (justStarted)
        {
            GetComponent<AudioSource>().Play();
            fire.SetActive(true);
            cameraEnemy.enabled = false;
            cameraFire.enabled = true;
            justStarted = false;
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            GetComponent<AudioSource>().Stop();
            TutorialManager.Instance.completedTutorial();
        }
    }
}
