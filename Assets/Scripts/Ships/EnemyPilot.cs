using System;
using UnityEngine;

class EnemyPilot : Pilot
{
    public float assaultDelay = 4.0f;
    public float minimalDistance = 7.0f;

    private float lastAssaultTime;

    public EnemyPilot(): base()
    {
        lastAssaultTime = 0.0f;
    }
    
    public override Vector3 GetRotationDecision(Transform current, Transform target)
    {
        Vector3 direction = Vector3.zero;

        // Following the target
        if (lastAssaultTime == 0.0f)
        {
            float distance = Vector3.Distance(current.position, target.position);

            if (distance < minimalDistance)
            {
                lastAssaultTime = Time.time;
            }

            direction = (target.position - current.position).normalized;

            // Noise move
            direction = AddNoise(direction);
        }
        else
        {
            if (Time.time > (lastAssaultTime + assaultDelay))
            {
                lastAssaultTime = 0.0f;
            }
            // Wait for the next assault
            return AddNoise(current.forward).normalized;
        }

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
