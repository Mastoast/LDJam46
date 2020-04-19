using System;
using UnityEngine;

class EnemyPilot : Pilot
{
    public override Vector3 GetRotationDecision(Transform current, Transform target)
    {
        float distance = Vector3.Distance(current.position, target.position);
        Vector3 direction;
        direction  = (target.position - current.position).normalized;

        // Noise move
        direction = AddNoise(direction);

        return direction;
    }

    public override Vector3 GetVelocityDecision(Transform self, Transform target)
    {
        return Vector3.one;
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
