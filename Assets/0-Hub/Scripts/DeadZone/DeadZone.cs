using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<DeadZoneAllowed>())
        {
            other.gameObject.transform.position = other.gameObject.GetComponent<DeadZoneAllowed>().defaultPosition;
            other.gameObject.transform.rotation = other.gameObject.GetComponent<DeadZoneAllowed>().defaultRotation;
            other.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
        }
    }
}
