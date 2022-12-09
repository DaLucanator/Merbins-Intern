using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRequireSpeed : MonoBehaviour
{
    //[SerializeField] Rigidbody rb;
    Vector3 was;
    [SerializeField] BoxCollider triggerBox;
    public bool held;
    bool moving;
    bool wasActive;
    [SerializeField] float requiredMagnitude;

    private void FixedUpdate()
    {

        moving = (was - transform.position).magnitude >= requiredMagnitude ? true:false;
        //Debug.Log($"Currently moving at {(was - transform.position).magnitude}");
        was = transform.position;
        if (held && moving)
        {//turn on
            if (!wasActive) 
            { 
                triggerBox.enabled = true;
                wasActive = true;
            }
        }
        else
        {
            if (wasActive)
            {
                triggerBox.enabled = false;
                wasActive = false;
            }
        }
    }

    public void UpdatingHolding(bool now)
    {
        held = now;
    }


}
