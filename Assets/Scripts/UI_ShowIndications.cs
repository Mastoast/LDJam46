using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_ShowIndications : MonoBehaviour
{
    // Put this script on Ship Zone Triggers

    public ShipMap shipMapScript;
    public Canvas canvas;
    public GameObject popupWindow;

    bool _isColliding = false;

    IEnumerator ShowIndications(string type, string position)
    {
        GameObject window = Instantiate(popupWindow, canvas.transform);

        float x = 150f + Random.Range(0f, Screen.width - 300f);
        float y = 75f + Random.Range(0f, Screen.height - 150f);

        window.transform.position = new Vector3(x, y, 0f);

        string p = "";

        switch (position)
        {
            case "ColliderAileGauche":
                shipMapScript.LeftWing();
                p = "left wing";
                break;

            case "ColliderAileDroite":
                shipMapScript.RightWing();
                p = "right wing";
                break;

            case "ColliderAvant":
                shipMapScript.Front();
                p = "front";
                break;

            case "ColliderCentre":
                shipMapScript.Center();
                p = "center";
                break;

            case "ColliderArriere":
                shipMapScript.Back();
                p = "back";
                break;
        }

        window.GetComponentInChildren<Text>().text = type + " in the " + p + " !";

        // Wait for 5 seconds
        yield return new WaitForSeconds(5);

        Destroy(window);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_isColliding) return;
        _isColliding = true;

        if (other.tag.Equals("Breach"))
            StartCoroutine(ShowIndications("Breach", name));

        if (other.tag.Equals("Fire"))
            StartCoroutine(ShowIndications("Fire", name));

        StartCoroutine(Reset());
    }

    IEnumerator Reset()
    {
        yield return new WaitForEndOfFrame();
        _isColliding = false;
    }
}
