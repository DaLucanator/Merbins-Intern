using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DetectCount : MonoBehaviour
{
    [SerializeField] int expectCount;
    [SerializeField] int currentCount;

    public UnityEvent CountExpect;

    void Update()
    {
        if (currentCount == expectCount)
        {
            CountExpect.Invoke();
        }
    }
    public void DetectCountNumber()
    {
        ++currentCount;
    }
}
