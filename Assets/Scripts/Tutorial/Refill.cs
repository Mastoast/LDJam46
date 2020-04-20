using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refill : Tutorial
{
    public Stock stock;
    public override void checkIfHappening()
    {
        if (stock.bonbonne > 0)
        {
            TutorialManager.Instance.completedTutorial();
        }
    }
}
