using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(HingeJoint))]
[RequireComponent(typeof(Rigidbody))]


public class DoorCreak : MonoBehaviour
{
    HingeJoint hJ;
    AudioSource aS;
    Rigidbody rb;
    bool canMakeSound;


    private void OnEnable()
    {
        hJ = GetComponent<HingeJoint>();
        aS = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        if (canMakeSound)
        {

            if (40 < transform.localEulerAngles.y && transform.localEulerAngles.y < 50)
            {
                aS.Play();
                canMakeSound = false;
            }
        }
        else
        {
            if (40 > transform.localEulerAngles.y || transform.localEulerAngles.y > 50)
            {
                canMakeSound = true;
            }
        }
    }


}
