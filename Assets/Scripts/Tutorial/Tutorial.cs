﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public int order;
    [TextArea]
    public string explanation;

    void Awake()
    {
        TutorialManager.Instance.tutorials.Add(this);
    }

    public virtual void checkIfHappening(){}
    
}
