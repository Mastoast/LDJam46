using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_ShowIndications : MonoBehaviour
{
    // Put this script anywhere

    public Text textIndication;

    void Start()
    {
        textIndication.text = "";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T)) // Simulate damage taken
            StartCoroutine(ShowIndications("L'aile gauche a été touchée !"));

        if (Input.GetKeyDown(KeyCode.Y)) // Simulate damage taken
            StartCoroutine(ShowIndications("L'aile droite a été touchée !"));

        if (Input.GetKeyDown(KeyCode.U)) // Simulate damage taken
            StartCoroutine(ShowIndications("Le cockpit a été touché !"));
    }

    IEnumerator ShowIndications(string str)
    {
        // Show the text
        textIndication.text += str + System.Environment.NewLine;

        // Wait for 5 seconds
        yield return new WaitForSeconds(5);

        // Hide the text
        int index = textIndication.text.IndexOf(System.Environment.NewLine);
        textIndication.text = textIndication.text.Substring(index + System.Environment.NewLine.Length);
    }
}
