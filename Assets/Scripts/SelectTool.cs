using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectTool : MonoBehaviour
{
    // Put this script anywhere

    public enum Tools
    {
        NONE,
        SOUDEUR,
        EXTINCTEUR
    }

    public Tools tool = Tools.NONE;

    public Text textTool;

    void Start()
    {
        textTool.text = "No current tool";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G)) // Simulate tool switching
        {
            tool = Tools.NONE;
            textTool.text = "No current tool";
        }

        if (Input.GetKeyDown(KeyCode.H)) // Simulate tool switching
        {
            tool = Tools.SOUDEUR;
            textTool.text = "Current tool : Soudeur";
        }

        if (Input.GetKeyDown(KeyCode.J)) // Simulate tool switching
        {
            tool = Tools.EXTINCTEUR;
            textTool.text = "Current tool : Extincteur";
        }
    }
}
