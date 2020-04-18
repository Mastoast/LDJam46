using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_ShowIndications : MonoBehaviour
{
    // Put this script anywhere

    public Canvas canvas;
    public GameObject popupWindow;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Simulate damage taken
        {
            float r = Random.Range(0f, 1.1f);
            string s = "";

            if (r < 0.1f) s = "L'aile gauche a été touchée !";
            else if (r < 0.2f) s = "L'aile droite a été touchée !";
            else if (r < 0.3f) s = "L'aile gauche a été endommagée !";
            else if (r < 0.4f) s = "L'aile droite a été endommagée !";
            else if (r < 0.5f) s = "Le cockpit a été touchée !";
            else if (r < 0.6f) s = "Le cockpit a été endommagé !";
            else if (r < 0.7f) s = "Thomas est une chèvre !";
            else if (r < 0.8f) s = "Hector est une anguille !";
            else if (r < 0.9f) s = "Guillaume est un canard !";
            else if (r < 1.0f) s = "Théo est une fourmi !";
            else s = "Cyril est le plus beau et le plus fort !";

            StartCoroutine(ShowIndications(s));
        }
    }

    IEnumerator ShowIndications(string str)
    {
        GameObject window = Instantiate(popupWindow, canvas.transform);

        float x = 150f + Random.Range(0f, Screen.width - 300f);
        float y = 75f + Random.Range(0f, Screen.height - 150f);

        window.transform.position = new Vector3(x, y, 0f);

        window.GetComponentInChildren<Text>().text = str;

        // Wait for 5 seconds
        yield return new WaitForSeconds(5);

        Destroy(window);
    }
}
