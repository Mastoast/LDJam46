using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Repair : MonoBehaviour
{
    // Put this script on the Player

    public Stock stock;
    public SelectTool selectTool;
    public Text textAction;
    public Slider slider;

    GameObject goToRepair = null;

    bool _onFire = false;
    bool _onBreach = false;

    bool _onStock = false;

    int repairCost = 20;

    private void Start()
    {
        textAction.text = "";
        slider.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (_onStock)
            {
                textAction.text = "Refilling...";
                StartCoroutine(Refilling());
            }
            else if (goToRepair != null)
            {
                if (_onFire)
                {
                    if (selectTool.tool == SelectTool.Tools.EXTINCTEUR)
                    {
                        if (stock.GetMetal() >= repairCost)
                        {
                            textAction.text = "Extinguishing fire...";
                            StartCoroutine(Repairing());
                            stock.ChangeBonbonne(-repairCost);
                            _onFire = false;
                        }
                        else textAction.text = "Not enough Metal";
                    }
                    else textAction.text = "No Extincteur equiped";
                }
                else if (_onBreach)
                {
                    if (selectTool.tool == SelectTool.Tools.SOUDEUR)
                    {
                        if (stock.GetBonbonne() >= repairCost)
                        {
                            textAction.text = "Repairing breach...";
                            StartCoroutine(Repairing());
                            stock.ChangeMetal(-repairCost);
                            _onBreach = false;
                        }
                        else textAction.text = "Not enough Bonbonne";
                    }
                    else textAction.text = "No Soudeur equiped";
                }
                else textAction.text = "No Fire or Breach near";
            }
            else textAction.text = "Nothing to interact with";
        }
    }

    IEnumerator Refilling()
    {
        // Disable movement while repairing
        gameObject.GetComponent<CharacterController>().enabled = false;

        slider.gameObject.SetActive(true);

        float timer = 3f;

        while (timer > 0f)
        {
            timer -= Time.deltaTime;

            slider.value = 1 - (timer / 3f);

            yield return new WaitForEndOfFrame();
        }

        stock.ChangeBonbonne(50);
        stock.ChangeMetal(50);

        // Enable movement
        gameObject.GetComponent<CharacterController>().enabled = true;

        textAction.text = "";

        slider.value = 0f;

        slider.gameObject.SetActive(false);
    }

    IEnumerator Repairing()
    {
        // Disable movement while repairing
        gameObject.GetComponent<CharacterController>().enabled = false;

        slider.gameObject.SetActive(true);

        float timer = 5f;

        while (timer > 0f)
        {
            timer -= Time.deltaTime;

            slider.value = 1 - (timer / 5f);

            yield return new WaitForEndOfFrame();
        }

        Destroy(goToRepair);
        goToRepair = null;

        // Enable movement
        gameObject.GetComponent<CharacterController>().enabled = true;

        textAction.text = "";

        slider.value = 0f;

        slider.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Fire"))
        {
            _onFire = true;
            goToRepair = other.gameObject;
            textAction.text = "Press E to put out fire";
        }
        else if (other.tag.Equals("Breach"))
        {
            _onBreach = true;
            goToRepair = other.gameObject;
            textAction.text = "Press E to repair breach";
        }
        else if (other.tag.Equals("Stock"))
        {
            _onStock = true;
            textAction.text = "Press E to refill your metal and bonbonne";
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Fire"))
        {
            _onFire = false;
            goToRepair = null;
            textAction.text = "";
        }
        else if (other.tag.Equals("Breach"))
        {
            _onBreach = false;
            goToRepair = null;
            textAction.text = "";
        }
        else if (other.tag.Equals("Stock"))
        {
            _onStock = false;
            textAction.text = "";
        }
    }
}
