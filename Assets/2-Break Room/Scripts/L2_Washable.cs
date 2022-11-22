using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L2_Washable : MonoBehaviour
{
    [SerializeField] GameObject donePrefab;
    public void doneParticles()
    {
        Instantiate(donePrefab, transform.position, Quaternion.identity) ;
    }
}
