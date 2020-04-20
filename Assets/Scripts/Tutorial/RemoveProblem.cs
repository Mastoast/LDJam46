using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveProblem : Tutorial
{
    public GameObject problem;
    private float startTime;
    private bool justStarted = true;
    private bool justFinished = true;
    public override void checkIfHappening()
    {
        if (justStarted)
        {
            if(GetComponent<AudioSource>())
            GetComponent<AudioSource>().Play();
            justStarted = false;
        }
        if (!problem)
        {
            if (justFinished)
            {
                if (GetComponent<AudioSource>())
                    GetComponent<AudioSource>().Stop();
                TutorialManager.Instance.actionFinished();
                startTime = Time.time;
                justFinished = false;

            }
            if(Time.time - startTime > 2)
            {
                TutorialManager.Instance.completedTutorial();

            }
        }
    }
}
