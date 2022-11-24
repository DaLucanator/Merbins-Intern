using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L2_FloatUntilPickup : MonoBehaviour
{
    Vector3 startpos;

    private void OnEnable()
    {
        startpos = transform.position;
        
    }

    private void FixedUpdate()
    {
        if (transform.position != startpos)
        {
            GetComponent<Rigidbody>().useGravity = true;
            this.enabled = false;
        }
    }

}
