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

    public Vector3 AddNoise(Vector3 vector)
    {
        return new Vector3(
            vector.x * UnityEngine.Random.Range(0.9f, 1.1f),
            vector.y * UnityEngine.Random.Range(0.9f, 1.1f),
            vector.z * UnityEngine.Random.Range(0.9f, 1.1f)
        );
    }
}