using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGame_Breach : MonoBehaviour
{
    public Canvas canvas;
    public GameObject window;

    public bool playing = false;

    Transform _smoke = null;

    float _particleSize;

    char[] _alpha = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

    KeyCode _key;

    bool _keyFound = false;
    bool _wrongKey = false;

    public void LaunchMiniGame(GameObject go)
    {
        playing = true;

        _particleSize = 0.5f;

        _smoke = go.transform.Find("white_smoke");

        StartCoroutine(Game());
    }

    IEnumerator Game()
    {
        yield return new WaitForSeconds(Random.Range(0.5f, 1f));

        char c = _alpha[Random.Range(0, 26)];

        GameObject go = Instantiate(window, canvas.transform);

        float x = 250f + Random.Range(0f, Screen.width - 500f);
        float y = 150f + Random.Range(0f, Screen.height - 300f);

        go.transform.position = new Vector3(x, y, 0f);

        go.GetComponentInChildren<Text>().text = c.ToString();

        _key = (KeyCode)System.Enum.Parse(typeof(KeyCode), c.ToString());

        while (!_keyFound && !_wrongKey)
        {
            yield return new WaitForEndOfFrame();
        }

        if (_keyFound)
        {
            _particleSize -= 0.1f;
            _smoke.localScale = Vector3.one * _particleSize;
        }

        _key = KeyCode.None;
        _keyFound = false;
        _wrongKey = false;

        Destroy(go);

        if (_particleSize > 0.01f)
            StartCoroutine(Game());
        else
            playing = false;
    }

    void Update()
    {
        if (playing)
        {
            foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(vKey))
                {
                    if (vKey == _key)
                        _keyFound = true;
                    else
                        _wrongKey = true;
                }
            }
        }
        
    }
}
