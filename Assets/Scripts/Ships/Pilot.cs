using UnityEngine;


public class Pilot
{
    public virtual Vector3 GetRotationDecision(Transform self, Transform target)
    {
        // Return between 0 and 1
        return Vector3.zero;
    }

    public virtual Vector3 GetVelocityDecision(Transform self, Transform target)
    {
        return Vector3.zero;
    }
}