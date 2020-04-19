using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectTool : MonoBehaviour
{
    // Put this script anywhere

    public Image _currentUI;

    public Sprite UI_NONE;
    public Sprite UI_EXTINCTEUR;
    public Sprite UI_SOUDEUR;

    public GameObject extinguisher;
    public GameObject soldering;

    public bool canMove = true;

    public enum Tools
    {
        NONE,
        SOUDEUR,
        EXTINCTEUR
    }

    // Current tool held in hand
    public Tools tool = Tools.NONE;

    private void Start()
    {
        _currentUI.sprite = UI_NONE;
    }

    void Update()
    {
        if (canMove)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                if (tool == Tools.EXTINCTEUR)
                {
                    tool = Tools.NONE;
                    _currentUI.sprite = UI_NONE;
                    extinguisher.SetActive(false);
                    soldering.SetActive(false);
                }
                else
                {
                    tool = Tools.EXTINCTEUR;
                    _currentUI.sprite = UI_EXTINCTEUR;
                    extinguisher.SetActive(true);
                }
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                if (tool == Tools.SOUDEUR)
                {
                    tool = Tools.NONE;
                    _currentUI.sprite = UI_NONE;
                    extinguisher.SetActive(false);
                    soldering.SetActive(false);
                }
                else
                {
                    tool = Tools.SOUDEUR;
                    _currentUI.sprite = UI_SOUDEUR;
                    soldering.SetActive(true);
                }
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                tool = Tools.NONE;
                _currentUI.sprite = UI_NONE;
                extinguisher.SetActive(false);
                soldering.SetActive(false);
            }
        }
    }
}
