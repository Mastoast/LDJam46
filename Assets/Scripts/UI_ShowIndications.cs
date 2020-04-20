using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_ShowIndications : MonoBehaviour
{
    // Put this script on Ship Zone Triggers

    public Canvas canvas;
    public GameObject popupWindow;

    bool _isColliding = false;

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

    private void OnTriggerEnter(Collider other)
    {
        if (_isColliding) return;
        _isColliding = true;

        if (other.tag.Equals("Breach"))
            StartCoroutine(ShowIndications("Breach in " + name));

        if (other.tag.Equals("Fire"))
            StartCoroutine(ShowIndications("Fire in " + name));

        StartCoroutine(Reset());
    }

    IEnumerator Reset()
    {
        yield return new WaitForEndOfFrame();
        _isColliding = false;
    }
}
