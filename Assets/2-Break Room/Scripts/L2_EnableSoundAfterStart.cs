using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(DBAudioEventFall))]
public class L2_EnableSoundAfterStart : MonoBehaviour
{
    AudioSource DBAE;

    private void OnEnable()
    {
        DBAE = GetComponent<AudioSource>();
        DBAE.enabled = false;
        StartCoroutine(startDelay());
    }

    IEnumerator startDelay()
    {
        yield return new WaitForSeconds(1);
        DBAE.enabled = true;
        Destroy(this);
    }
}
