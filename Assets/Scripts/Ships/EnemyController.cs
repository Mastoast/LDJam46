using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : ShipController
{
    public GameObject bidule;
    public GameObject breach;

    private MeshCollider shipCollider;

    bool _justSpawned = false;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Ship");
        pilot = new EnemyPilot();
        shipCollider = target.GetComponentInChildren<MeshCollider>();
    }

    void Update()
    {

        RaycastHit hit1;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), out hit1, Mathf.Infinity))
            if (hit1.collider == shipCollider)
            {
                if (!_justSpawned)
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up) * hit1.distance, Color.red);
                    StartCoroutine(SpawnBidule(hit1));
                }
                else
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up) * hit1.distance, Color.yellow);
            }


        RaycastHit hit2;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit2, Mathf.Infinity))
            if (hit2.collider == shipCollider)
            {
                if (!_justSpawned)
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit2.distance, Color.red);
                    StartCoroutine(SpawnBidule(hit2));
                }
                else
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit2.distance, Color.yellow);
            }
    }

    IEnumerator SpawnBidule(RaycastHit hit)
    {
        _justSpawned = true;

        GameObject hitPos = new GameObject();
        hitPos.transform.position = hit.point;
        hitPos.transform.parent = target.transform;

        GameObject go = Instantiate(bidule, target.transform);

        Vector3[] n = shipCollider.sharedMesh.normals;
        int[] tri = shipCollider.sharedMesh.triangles;

        Vector3 n0 = n[tri[hit.triangleIndex * 3 + 0]];
        Vector3 n1 = n[tri[hit.triangleIndex * 3 + 1]];
        Vector3 n2 = n[tri[hit.triangleIndex * 3 + 2]];
        Vector3 c = hit.barycentricCoordinate;
        Vector3 normal = hit.transform.TransformDirection((n0 * c.x + n1 * c.y + n2 * c.z).normalized);

        go.transform.up = normal;

        while (Vector3.Distance(go.transform.localPosition, hitPos.transform.localPosition) > 1f)
        {
            go.transform.localPosition = Vector3.MoveTowards(go.transform.localPosition, hitPos.transform.localPosition, Time.deltaTime * 20);

            yield return new WaitForEndOfFrame();
        }

        GameObject b = Instantiate(breach, target.transform);
        b.transform.localPosition = go.transform.localPosition;
        b.transform.up = go.transform.up;

        // Damages
        target.GetComponent<AllyController>().hullPoints -= target.GetComponent<AllyController>().damageAmount;

        _justSpawned = false;
    }

    void FixedUpdate()
    {
        GetDecision();
        Move();
    }
}
