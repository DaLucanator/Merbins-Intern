using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using Unity.VisualScripting;
using UnityEngine;

public class BaseDefencePortalableObject : MonoBehaviour
{
    [SerializeField]
    private float portalCooldown;
    [SerializeField]
    private float portalVelocityMultiplier = 1f;
    private Rigidbody rb;
    private BaseDefensePortal inPortal, outPortal;
    [SerializeField]private bool canPortal = true;

    private static readonly Quaternion halfTurn = Quaternion.Euler(0f, 180f,180f)  ;

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider collider)
    {
        if(canPortal)
        {
            inPortal = collider.GetComponent<BaseDefensePortal>();
            if (inPortal.IsActivated())
            {
                outPortal = inPortal.GetOtherPortal();

                Physics.IgnoreCollision(outPortal.GetComponent<Collider>(), gameObject.GetComponent<Collider>(), true);
                Physics.IgnoreCollision(collider, gameObject.GetComponent<Collider>(), true);

                StartCoroutine(PortalCooldown(collider));

                Transform inTransform = inPortal.transform;
                Transform outTransform = outPortal.GetSpawnPos().transform;

                Debug.Log(outTransform.position.ToString());

                // Update position of object.
                Vector3 relativePos = inTransform.InverseTransformPoint(transform.position);
                relativePos = halfTurn * relativePos;
                transform.position = outTransform.TransformPoint(relativePos);

                // Update rotation of object.
                Quaternion relativeRot = Quaternion.Inverse(inTransform.rotation) * transform.rotation;
                relativeRot *= halfTurn;
                transform.rotation = outTransform.rotation * relativeRot;

                // Update velocity of rigidbody.
                Vector3 relativeVel = inTransform.InverseTransformDirection(rb.velocity);
                relativeVel = halfTurn * relativeVel;
                rb.velocity = (outTransform.TransformDirection(relativeVel)) * portalVelocityMultiplier;

                canPortal = false;
            }
        }

    }


    private IEnumerator PortalCooldown(Collider collider)
    {
        yield return new WaitForSeconds(portalCooldown);

        Physics.IgnoreCollision(collider, gameObject.GetComponent<Collider>(), false);
        Physics.IgnoreCollision(outPortal.GetComponent<Collider>(), gameObject.GetComponent<Collider>(), false);

        canPortal = true;

    }
}
