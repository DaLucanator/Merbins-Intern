using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorHitPlaySound : MonoBehaviour
{
    //define the audio source attached to an object
    public AudioSource audioHitFloor;

    void OnCollisionEnter(Collision other)
    {
        //when this object hits the floor
        if (other.gameObject.CompareTag("Floor"))
        {
            //if this object is moving at a high speed
            if (other.relativeVelocity.magnitude > 1.5f)
            {
                //plays an impact sound
                Debug.Log("Hit floor audio playing!");
                audioHitFloor.Play();
            }
            //otherwise, doesn't play audio
        }
    }
}
