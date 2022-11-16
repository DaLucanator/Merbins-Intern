using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactZ : MonoBehaviour
{
    public Transform cam;
    Rigidbody rb;
    public bool Button;

    public float throwForce;
    public float throwUpWardForce;

    private Rigidbody[] _ragdollRigidbodies;

    // Start is called before the first frame update
    void Awake()
    {
        cam = GameObject.FindGameObjectWithTag("Player").transform;

        rb = gameObject.GetComponent<Rigidbody>();
        _ragdollRigidbodies = GetComponentsInChildren<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Button == true)
        {
            Vector3 forceToAdd = cam.transform.forward * throwForce + transform.up * throwUpWardForce;
            _ragdollRigidbodies[1].AddForce(forceToAdd, ForceMode.Impulse);

            Button = false;
        }
        
    }

    public void ButtonON()
    {
        Button = true;
    }
}
