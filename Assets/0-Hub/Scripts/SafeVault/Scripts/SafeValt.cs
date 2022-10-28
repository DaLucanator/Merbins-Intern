using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class SafeValt : MonoBehaviour
{
    public Vector3 expectedCount;
    public Vector3 currentCount;

    [SerializeField] Text keyPad1;
    [SerializeField] Text keyPad2;
    [SerializeField] Text keyPad3;

    public UnityEvent CountExpectCallOnce;
    public UnityEvent CountExpectUpdate;

    bool callOnce;

    void Update()
    {
        keyPad1.text = "" + currentCount.x;
        keyPad2.text = "" + currentCount.y;
        keyPad3.text = "" + currentCount.z;

        // Call every frame Invoke
        if (currentCount == expectedCount) { CountExpectUpdate.Invoke(); }

        // Call Once Invoke
        if (currentCount != expectedCount) { callOnce = false; }
        if (!callOnce) { if (currentCount == expectedCount) { CountExpectCallOnce.Invoke(); callOnce = true; } }
    }

    // NumberPad 1# Green
    public void CountNumberN1UP() {
        ++currentCount.x;
        if (currentCount.x > 9) { currentCount.x = 0; }
    }
    public void CountNumberN1DOWN() { 
        --currentCount.x;
        if (currentCount.x < 0) { currentCount.x = 9; }
    }

    // NumberPad 2# Red
    public void CountNumberN2UP() {
        ++currentCount.y;
        if (currentCount.y > 9) { currentCount.y = 0; }
    }
    public void CountNumberN2DOWN() { 
        --currentCount.y;
        if (currentCount.y < 0) { currentCount.y = 9; }
    }

    // NumberPad 3# Blue
    public void CountNumberN3UP() {
        ++currentCount.z;
        if (currentCount.z > 9) { currentCount.z = 0; }
    }
    public void CountNumberN3DOWN() { 
        --currentCount.z;
        if (currentCount.z < 0) { currentCount.z = 9; }
    }
}
