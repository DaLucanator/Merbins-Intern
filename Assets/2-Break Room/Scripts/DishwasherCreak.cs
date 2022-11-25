using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(HingeJoint))]
[RequireComponent(typeof(Rigidbody))]


public class DishwasherCreak : MonoBehaviour
{
    AudioSource aS;
    bool canMakeSound;


    private void OnEnable()
    {
        aS = GetComponent<AudioSource>();
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
