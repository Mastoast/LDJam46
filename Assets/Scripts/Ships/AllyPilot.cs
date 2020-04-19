using System;
using UnityEngine;

class AllyPilot : Pilot
{

    public AllyPilot(): base()
    {
    }
    
    public override Vector3 GetRotationDecision(Transform current, Transform target)
    {
        Vector3 direction = Vector3.forward;

        return direction;
    }

    public override Vector3 GetVelocityDecision(Transform self, Transform target)
    {
        return Vector3.one;
    }
}
