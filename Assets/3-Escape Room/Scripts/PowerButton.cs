using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerButton : MonoBehaviour
{
	public ERFuseBox fuseBox;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Touch"))
        {
            fuseBox.restorePower();
        }
    }
}
