using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToCC : Tutorial
{
    public SphereCollider pcol;
    public BoxCollider triggerZone;
    private bool justStarted = true;
    private bool justFinished = true;
    private float startTime;

    public override void checkIfHappening()
    {
        if (justStarted)
        {
            GetComponent<AudioSource>().Play();
            justStarted = false;
        }
        if (triggerZone.bounds.Intersects(pcol.bounds))
        {
            if (justFinished)
            {
                GetComponent<AudioSource>().Stop();
                TutorialManager.Instance.actionFinished();
                justFinished = false;
                startTime = Time.time;
            }
            if (Time.time - startTime > 2)
                TutorialManager.Instance.completedTutorial();
        }
    }
}
