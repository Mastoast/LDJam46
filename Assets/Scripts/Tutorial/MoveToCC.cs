using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToCC : Tutorial
{
    public SphereCollider pcol;
    public BoxCollider triggerZone;

    public override void checkIfHappening()
    {
        if (triggerZone.bounds.Intersects(pcol.bounds))
        {
            TutorialManager.Instance.completedTutorial();
        }
    }
}
