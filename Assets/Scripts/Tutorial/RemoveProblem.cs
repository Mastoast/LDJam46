using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveProblem : Tutorial
{
    public GameObject problem;
    private float startTime;
    private bool justFinished = true;
    public override void checkIfHappening()
    {
        if (!problem)
        {
            if (justFinished)
            {
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
