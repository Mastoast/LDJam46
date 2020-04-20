using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowRobot : Tutorial
{
    public GameObject enemy;
    public GameObject fire;
    public GameObject breach;
    public AllyController vaisseau;
    public GameObject entireMesh;
    public GameObject armMesh;
    public List<Camera> allCameras;
    public Camera cameraRobot;
    public PlayerMovement pm;
    public Canvas canvas;
    private float startTime;
    private bool justStarted = true;

        
    public override void checkIfHappening()
    {
        if (justStarted)
        {

            foreach(Camera c in allCameras)
            {
                c.enabled = false;
            }
            cameraRobot.enabled = true;

            fire.SetActive(false);
            enemy.SetActive(false);
            breach.SetActive(false);
            canvas.enabled = false;
            pm.enabled = false;
            armMesh.SetActive(false);
            entireMesh.SetActive(true);

            vaisseau.movementSpeed = 0.0f;
            vaisseau.rotationSpeed = 0.0f;
            startTime = Time.time;
            justStarted = false;
        }
        if(Time.time - startTime > 2)
        {
            vaisseau.movementSpeed = 100.0f;
            vaisseau.rotationSpeed = 0.1f;
            TutorialManager.Instance.completedTutorial();
        }
    }
}
