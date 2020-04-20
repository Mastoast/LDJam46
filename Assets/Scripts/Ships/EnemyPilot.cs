using UnityEngine;

class EnemyPilot : Pilot
{
    public float assaultDelay = 4.0f;
    public float minimalDistance = 350.0f;

    private float lastAssaultTime;
    private Vector3 noise;

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

                // add random noise
                noise = new Vector3(Random.Range(0.0f, 0.5f), Random.Range(0.0f, 0.5f), Random.Range(0.0f, 0.5f));
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
            else
            {
                direction = noise;
            }
            
        }

        return direction;
    }

    public override Vector3 GetVelocityDecision(Transform self, Transform target)
    {
        return Vector3.one;
    }
}
