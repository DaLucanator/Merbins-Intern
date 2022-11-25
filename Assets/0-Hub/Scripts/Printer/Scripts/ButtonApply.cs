using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonApply : MonoBehaviour
{
    public UnityEvent invokeButton;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Touch"))
        {
            invokeButton.Invoke();
        }
    }
}
