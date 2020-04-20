using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllyController : ShipController
{
    public Slider shipHealth;
    public GameObject gameOverWindow;
    public float hullPoints = 100f;
    public float damageAmount = 7.5f;

    //End of game timer
    public Text timerRecord;

    // Start is called before the first frame update
    void Start()
    {
        target = new GameObject();
        target.SetActive(true);
        target.transform.position = new Vector3(100, 50, 0);
        pilot = new AllyPilot();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.frameCount%(60*45) == 1)
        {
            target.transform.position = new Vector3(
                Random.Range(-2000, 2000),
                Random.Range(-2000, 2000),
                Random.Range(-2000, 2000)
            );
        }

        //shipHealth.value = hullPoints / 100f;

        // Overall ship is too damaged => GAME OVER
        if (hullPoints <= 0f)
        {
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
            gameOverWindow.SetActive(true);
            gameOverWindow.GetComponentInChildren<Text>().text = "GAMEOVER\n The ship took too much damage.";
            timerRecord.text = "Timer : " + System.Math.Round(Time.timeSinceLevelLoad, 2) + " s";
        }
    }

    void FixedUpdate()
    {
        GetDecision();
        Move();
    }

    public void RepairedPart(float coef)
    {
        hullPoints += damageAmount * coef;
    }
}
