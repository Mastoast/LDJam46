using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refill : Tutorial
{
    public Stock stock;
    private bool justFinished = true;
    private float startTime;
    public override void checkIfHappening()
    {
        if (stock.bonbonne > 0)
        {
            if (justFinished)
            {
                justFinished = false;
                startTime = Time.time;
            }
            if(Time.time - startTime > 2)
            TutorialManager.Instance.completedTutorial();
        }
    }
}
