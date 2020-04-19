using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBackgroundManager : MonoBehaviour
{
    public GameObject Starship;
    public float Speed = 20f;

    private Vector3 starshipMovement;


    void FixedUpdate()
    {
        starshipMovement = Starship.transform.forward * Speed;
        Starship.transform.localPosition = (Starship.transform.localPosition + starshipMovement);
    }
}
