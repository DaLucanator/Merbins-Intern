using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DBAudioEvent : MonoBehaviour
{
    [SerializeField] private UnityEvent audioTrigger;
    public float setVelocity = 1.5f;

    void OnCollisionEnter(Collision other)
    {
        //when this object hits the floor
        if (other.gameObject.CompareTag("Floor"))
        {
            //if this object is moving at a high enough speed
            if (other.relativeVelocity.magnitude > setVelocity)
            {
            //plays an impact sound
                Debug.Log("Hit floor audio playing!");
                audioTrigger.Invoke();
            }
            //otherwise, doesn't play audio
        }
    }
}
