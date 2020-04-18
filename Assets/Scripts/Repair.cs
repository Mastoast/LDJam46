using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Repair : MonoBehaviour
{
    // Put this script on the Player

    public Stock stock;
    public SelectTool selectTool;
    public PlayerMovement playerMovement;
    public Text textAction;
    public Slider slider;

    // GameObject that will be repaired
    GameObject _goToRepair = null;

    bool _onFire = false;
    bool _onBreach = false;
    bool _onStock = false;

    // How much metal or bonbonne will cost the repair
    int _repairCost = 20;

    private void Start()
    {
        textAction.text = "";
        slider.gameObject.SetActive(false);
    }

    private void Update()
    {
        // Action Key here is E
        if (Input.GetKeyDown(KeyCode.E))
        {
            // If near a stock cube
            if (_onStock)
            {
                textAction.text = "Refilling...";
                // Refill metal and bonbonne
                StartCoroutine(Refilling());
            }
            else if (_goToRepair != null)
            {
                // If near a fire cube
                if (_onFire)
                {
                    // If holding an Extincteur
                    if (selectTool.tool == SelectTool.Tools.EXTINCTEUR)
                    {
                        // If the player has enough Metal
                        if (stock.GetBonbonne() >= _repairCost)
                        {
                            textAction.text = "Extinguishing fire...";
                            // Repair
                            StartCoroutine(Repairing());
                            // Remove the stock used
                            stock.ChangeBonbonne(-_repairCost);
                            _onFire = false;
                        }
                        else textAction.text = "Not enough Bonbonne";
                    }
                    else textAction.text = "No Extincteur equiped";
                }
                // If near a breach
                else if (_onBreach)
                {
                    // If holding a Soudeur
                    if (selectTool.tool == SelectTool.Tools.SOUDEUR)
                    {
                        // If the player has enough Bonbonne
                        if (stock.GetMetal() >= _repairCost)
                        {
                            textAction.text = "Repairing breach...";
                            // Repair
                            StartCoroutine(Repairing());
                            // Remove the stock used
                            stock.ChangeMetal(-_repairCost);
                            _onBreach = false;
                        }
                        else textAction.text = "Not enough Metal";
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
        playerMovement.canMove = false;

        slider.gameObject.SetActive(true);

        float timer = 3f;

        // Slider filling
        while (timer > 0f)
        {
            timer -= Time.deltaTime;

            slider.value = 1 - (timer / 3f);

            yield return new WaitForEndOfFrame();
        }

        // Action
        stock.ChangeBonbonne(50);
        stock.ChangeMetal(50);

        // Enable movement
        playerMovement.canMove = true;

        // Reset values
        textAction.text = "";
        slider.value = 0f;

        slider.gameObject.SetActive(false);
    }

    IEnumerator Repairing()
    {
        // Disable movement while repairing
        playerMovement.canMove = false;

        slider.gameObject.SetActive(true);

        float timer = 1f;

        // Slider filling
        while (timer > 0f)
        {
            timer -= Time.deltaTime;

            slider.value = 1 - (timer / 5f);

            yield return new WaitForEndOfFrame();
        }

        // ACtion
        Destroy(_goToRepair);
        _goToRepair = null;

        // Enable movement
        playerMovement.canMove = true;

        // Reset values
        textAction.text = "";
        slider.value = 0f;

        slider.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Fire"))
        {
            _onFire = true;
            _goToRepair = other.gameObject;
            textAction.text = "Press E to put out fire";
        }
        else if (other.tag.Equals("Breach"))
        {
            _onBreach = true;
            _goToRepair = other.gameObject;
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
            _goToRepair = null;
            textAction.text = "";
        }
        else if (other.tag.Equals("Breach"))
        {
            _onBreach = false;
            _goToRepair = null;
            textAction.text = "";
        }
        else if (other.tag.Equals("Stock"))
        {
            _onStock = false;
            textAction.text = "";
        }
    }
}
