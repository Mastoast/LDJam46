using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiduleBreach : MonoBehaviour
{
    GameObject breach;
    bool deactivated = false;

    public void ReactivateBreach()
    {
        breach.name = "FreeBreach";

        foreach (Collider c in breach.GetComponents<Collider>())
        {
            c.enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Breach"))
        {
            if (!deactivated)
            {
                breach = other.gameObject;

                foreach (Collider c in breach.GetComponents<Collider>())
                {
                    c.enabled = false;
                }

                deactivated = true;
            }
        }
    }
}
