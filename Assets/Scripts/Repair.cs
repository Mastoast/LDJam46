﻿using System.Collections;
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
    public Animator animator;

    // Freeze player movement and camera
    public PlayerMovement playerMovement;
    public Mouse_LookAround mouse;

    // GameObject that will be repaired
    GameObject _goToRepair = null;

    bool _onFire = false;
    bool _onBreach = false;
    bool _onStock = false;

    bool _droneBusy = false;

    // How much metal or bonbonne will cost the repair
    int _repairCost = 20;

    private void Start()
    {
        textAction.text = "";
        slider.gameObject.SetActive(false);
    }

    private void Update()
    {
        // If drone isn't already doing something
        if (!_droneBusy)
        {
            // Action Key here is E
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (_goToRepair != null)
                {
                    // If near a stock cube
                    if (_onStock)
                    {
                        // If looking at the stock cube
                        RaycastHit hit;
                        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
                        {
                            if (hit.transform.tag.Equals("Stock"))
                            {
                                textAction.text = "Refilling...";
                                // Refill metal and bonbonne
                                StartCoroutine(Refilling());
                            }
                            else textAction.text = "Not looking at the stock cube";
                        }
                        else textAction.text = "Not looking at the stock cube";
                    }
                    // If near a fire cube
                    else if (_onFire)
                    {
                        // If looking at the fire
                        RaycastHit hit;
                        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
                        {
                            if (hit.transform.tag.Equals("Fire"))
                            {
                                // If holding an Extincteur
                                if (selectTool.tool == SelectTool.Tools.EXTINCTEUR)
                                {
                                    // If the player has enough Metal
                                    if (stock.GetBonbonne() >= _repairCost)
                                    {
                                        // Repair
                                        StartCoroutine(Extinguishing());
                                    }
                                    else textAction.text = "Not enough Bonbonne";
                                }
                                else textAction.text = "No Extincteur equiped";
                            }
                            else textAction.text = "Not looking at the fire";
                        }
                        else textAction.text = "Not looking at the fire";
                    }
                    // If near a breach
                    else if (_onBreach)
                    {
                        // If looking at the breach
                        RaycastHit hit;
                        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
                        {
                            if (hit.transform.tag.Equals("Breach"))
                            {
                                // If holding a Soudeur
                                if (selectTool.tool == SelectTool.Tools.SOUDEUR)
                                {
                                    // If the player has enough Bonbonne
                                    if (stock.GetMetal() >= _repairCost)
                                    {
                                        // Repair
                                        StartCoroutine(Repairing());
                                    }
                                    else textAction.text = "Not enough Metal";
                                }
                                else textAction.text = "No Soudeur equiped";
                            }
                            else textAction.text = "Not looking at the fire";
                        }
                        else textAction.text = "Not looking at the breach";
                    }
                    else textAction.text = "No cube near";
                }
                else textAction.text = "Nothing to interact with";
            }
        }
    }

    IEnumerator Refilling()
    {
        // Disable movement while repairing
        _droneBusy = true;
        playerMovement.canMove = false;
        mouse.canMove = false;
        selectTool.canMove = false;

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
        _droneBusy = false;
        playerMovement.canMove = true;
        mouse.canMove = true;
        selectTool.canMove = true;

        // Reset values
        textAction.text = "";
        slider.value = 0f;

        slider.gameObject.SetActive(false);
    }

    IEnumerator Extinguishing()
    {
        // Disable movement while repairing
        _droneBusy = true;
        playerMovement.canMove = false;
        mouse.canMove = false;
        selectTool.canMove = false;

        slider.gameObject.SetActive(true);
        textAction.text = "Extinguishing fire...";

        // Animation
        animator.SetTrigger("Extinguish");

        float timer = 5f;
        bool playing = false;

        // Slider filling
        while (timer > 0f)
        {
            timer -= Time.deltaTime;

            slider.value = 1 - (timer / 5f);

            if (timer < 4f && timer >= 1f && !playing)
            {
                selectTool.extinguisher.GetComponentInChildren<ParticleSystem>().Play();
                playing = true;
            }
            if (timer < 1f && playing)
            {
                selectTool.extinguisher.GetComponentInChildren<ParticleSystem>().Stop();
                playing = false;
            }

            yield return new WaitForEndOfFrame();
        }

        // Action
        Destroy(_goToRepair);
        _goToRepair = null;

        // Remove the stock used
        stock.ChangeBonbonne(-_repairCost);

        // Enable movement
        _droneBusy = false;
        playerMovement.canMove = true;
        mouse.canMove = true;
        selectTool.canMove = true;

        // Reset values
        textAction.text = "";
        slider.value = 0f;
        _onFire = false;

        slider.gameObject.SetActive(false);
    }

    IEnumerator Repairing()
    {
        // Disable movement while repairing
        _droneBusy = true;
        playerMovement.canMove = false;
        mouse.canMove = false;
        selectTool.canMove = false;

        slider.gameObject.SetActive(true);
        textAction.text = "Repairing breach...";

        // Animation
        animator.SetTrigger("Solder");

        float timer = 8f;
        bool playing = false;

        // Slider filling
        while (timer > 0f)
        {
            timer -= Time.deltaTime;

            slider.value = 1 - (timer / 8f);

            if (timer < 3.5f && timer >= 0.5f && !playing)
            {
                selectTool.soldering.GetComponentInChildren<ParticleSystem>().Play();
                playing = true;
            }
            if (timer < 0.5f && playing)
            {
                selectTool.soldering.GetComponentInChildren<ParticleSystem>().Stop();
                playing = false;
            }

            yield return new WaitForEndOfFrame();
        }

        // Action
        Destroy(_goToRepair);
        _goToRepair = null;

        // Remove the stock used
        stock.ChangeMetal(-_repairCost);

        // Enable movement
        _droneBusy = false;
        playerMovement.canMove = true;
        mouse.canMove = true;
        selectTool.canMove = true;

        // Reset values
        textAction.text = "";
        slider.value = 0f;
        _onBreach = false;

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
            _goToRepair = other.gameObject;
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
            _goToRepair = null;
            textAction.text = "";
        }
    }
}
