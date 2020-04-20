using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowBidule : Tutorial
{
    public GameObject bidule;
    public GameObject breach;
    public Camera cameraBidule;
    public Camera cameraPlayer;
    public PlayerMovement pm;
    public Canvas canvas;
    private float startTime;
    private bool justStarted = true;

        
    public override void checkIfHappening()
    {
        if (justStarted)
        {
            GetComponent<AudioSource>().Play();
            pm.enabled = false;
            canvas.enabled = false;
            bidule.SetActive(true);
            breach.SetActive(true);

            cameraPlayer.enabled = false;
            cameraBidule.enabled = true;

            startTime = Time.time;
            justStarted = false;
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            GetComponent<AudioSource>().Stop();
            cameraBidule.enabled = false;
            cameraPlayer.enabled = true;
            pm.enabled = true;
            canvas.enabled = true;
            TutorialManager.Instance.completedTutorial();
        }
    }
}
