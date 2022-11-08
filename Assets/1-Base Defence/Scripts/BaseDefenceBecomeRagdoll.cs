using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BaseDefenceBecomeRagdoll : MonoBehaviour
{
    public void BecomeRagdoll()
    {
        gameObject.AddComponent<Rigidbody>();
        if (gameObject.GetComponent<BaseDefenseEnemy>() != null) { gameObject.GetComponent<BaseDefenseEnemy>().enabled = false; }
        if (gameObject.GetComponent<NavMeshAgent>() != null) { gameObject.GetComponent<NavMeshAgent>().enabled = false; }
    }
}
