using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZoneAllowed : MonoBehaviour
{
    [HideInInspector] public Vector3 defaultPosition;
    [HideInInspector] public Quaternion defaultRotation;

    void Awake()
    {
        defaultPosition = transform.position;
        defaultRotation = transform.rotation;
    }
}
