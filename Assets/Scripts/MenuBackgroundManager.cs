using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBackgroundManager : MonoBehaviour
{
    public GameObject starship;
    public GameObject bidule;

    public float starshipMovementSpeed = 0.3f;
    public float biduleMovementSpeed = 0.05f;
    public float biduleRotationSpeed = 1f;


    private Vector3 starshipMovement;
    private Vector3 biduleMovement;
    private Vector3 biduleRotation;



    void FixedUpdate()
    {

        biduleMovement = bidule.transform.right * -biduleMovementSpeed;
        bidule.transform.localPosition = (bidule.transform.localPosition + biduleMovement);

        starshipMovement = starship.transform.forward * starshipMovementSpeed;
        starship.transform.localPosition = (starship.transform.localPosition + starshipMovement);
    }
}
