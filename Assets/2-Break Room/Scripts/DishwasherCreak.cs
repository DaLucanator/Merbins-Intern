using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(HingeJoint))]
[RequireComponent(typeof(Rigidbody))]


public class DishwasherCreak : MonoBehaviour
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

            if (40 < transform.localEulerAngles.x && transform.localEulerAngles.x < 50)
            {
                aS.Play();
                canMakeSound = false;
            }
        }
        else
        {
            if (40 > transform.localEulerAngles.x || transform.localEulerAngles.x > 50)
            {
                canMakeSound = true;
            }
        }
    }


}
