using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBackgroundManager : MonoBehaviour
{
    public GameObject starship;
    public GameObject biduleHandler;
    public GameObject bidule;

    public float starshipMovementSpeed = 0.3f;
    public float biduleMovementSpeed = 0.05f;
    public float biduleRotationSpeed = 25f;


    private Vector3 starshipMovement;
    private Vector3 biduleMovement;
    private Vector3 biduleRotation;



    void FixedUpdate()
    {
        bidule.transform.Rotate(Vector3.back * biduleRotationSpeed);

        biduleMovement = biduleHandler.transform.right * -biduleMovementSpeed;
        biduleHandler.transform.localPosition = (biduleHandler.transform.localPosition + biduleMovement);

        starshipMovement = starship.transform.forward * starshipMovementSpeed;
        starship.transform.localPosition = (starship.transform.localPosition + starshipMovement);
    }
}
