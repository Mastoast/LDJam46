using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBackgroundManager : MonoBehaviour
{
    public GameObject Starship;
    public float Speed = 20f;

    private Vector3 starshipMovement;

    // Start is called before the first frame update
    void Start()
    {
        starshipMovement = new Vector3(0f, 0f, -Speed);
    }

    void FixedUpdate()
    {
        Starship.transform.localPosition = (Starship.transform.localPosition + starshipMovement);
    }
}
