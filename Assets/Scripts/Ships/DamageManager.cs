﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager : MonoBehaviour
{
    public GameObject ship;
    public void OnDestroy()
    {
        ship.GetComponentInParent<AllyController>().RepairedPart();
    }
}