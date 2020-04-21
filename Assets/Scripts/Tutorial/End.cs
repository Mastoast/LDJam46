using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : Tutorial
{
    public GameObject entireMesh;
    public GameObject armMesh;
    public Camera cameraPlayer;
    public Camera cameraRobot;
    public PlayerMovement pm;
    public Canvas canvas;
    private float startTime;
    private bool justStarted = true;

        
    public override void checkIfHappening()
    {
        if (justStarted)
        {
            GetComponent<AudioSource>().Play();
            cameraPlayer.enabled = false;
            cameraRobot.enabled = true;
            
            canvas.enabled = false;
            pm.canMove = false;
            armMesh.SetActive(false);
            entireMesh.SetActive(true);
            
            startTime = Time.time;
            justStarted = false;
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            GetComponent<AudioSource>().Stop();
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("Menu");

        }
    }
}
