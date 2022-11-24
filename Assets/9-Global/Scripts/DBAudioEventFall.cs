using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DBAudioEventFall : MonoBehaviour
{
    
    //Creates a dropdown array you need to add this object within
    //Set the function within the script component's array to "AudioSource > Play()"
    [SerializeField] private UnityEvent audioTrigger;
    public float setVelocity = 1.5f;

    //Checks when this object has a collision with another object
    void OnCollisionEnter(Collision other)
    {
        //If this object hits the floor
        if (other.gameObject.CompareTag("Floor"))
        {
            //And if this object is moving at a high enough speed
            if (other.relativeVelocity.magnitude > setVelocity)
            {
                //plays an impact sound
                Debug.Log("Hit floor audio playing!");
                audioTrigger.Invoke();
            }
            //Otherwise, doesn't play audio
        }
    }
}
