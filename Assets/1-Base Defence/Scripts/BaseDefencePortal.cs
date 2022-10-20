using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnePortal : MonoBehaviour
{
    [SerializeField]
    private OnePortal otherPortal;

    [SerializeField]
    private Transform spawnPos;

    private static readonly float rayLength = 7.5f;

    public OnePortal GetOtherPortal()
    {
        return otherPortal;
    }

    public Transform GetSpawnPos()
    {
        return spawnPos;
    }

    void OnDrawGizmos()
    {
        Vector3 direction = (otherPortal.transform.position - transform.position).normalized;
        Gizmos.DrawRay(transform.position, direction * rayLength) ;
    }
}
