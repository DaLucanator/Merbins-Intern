using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnePortalableObject : MonoBehaviour
{
    [SerializeField]
    private float portalCooldown;
    [SerializeField]
    private float portalVelocityMultiplier = 1f;
    private Rigidbody rb;
    private OnePortal inPortal, outPortal;
    private bool canPortal = true;

    private static readonly Quaternion halfTurn = Quaternion.Euler(-90f, 180f, 0.0f);

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.GetComponent<OnePortal>() != null && canPortal)
        {
            PortalCooldown(collision.collider);
            inPortal = collision.collider.GetComponent<OnePortal>();
            outPortal = inPortal.GetOtherPortal();

            Physics.IgnoreCollision(outPortal.GetComponent<Collider>(), gameObject.GetComponent<Collider>(), true);
            Physics.IgnoreCollision(collision.collider, gameObject.GetComponent<Collider>(), true);

            var inTransform = inPortal.transform;
            var outTransform = outPortal.GetSpawnPos().transform;

            // Update position of object.
            Vector3 relativePos = inTransform.InverseTransformPoint(transform.position);
            relativePos = halfTurn * relativePos;
            transform.position = outTransform.TransformPoint(relativePos);

            // Update rotation of object.
            Quaternion relativeRot = Quaternion.Inverse(inTransform.rotation) * transform.rotation;
            relativeRot = halfTurn * relativeRot;
            transform.rotation = outTransform.rotation * relativeRot;

            // Update velocity of rigidbody.
            Vector3 relativeVel = inTransform.InverseTransformDirection(rb.velocity);
            relativeVel = halfTurn * relativeVel;
            rb.velocity = (outTransform.TransformDirection(relativeVel)) * portalVelocityMultiplier;

            canPortal = false;
        }
    }


   private IEnumerator PortalCooldown(Collider collider)
    {
        yield return new WaitForSeconds(portalCooldown);

        canPortal = true;
        Physics.IgnoreCollision(collider, gameObject.GetComponent<Collider>(), false);
        Physics.IgnoreCollision(outPortal.GetComponent<Collider>(), gameObject.GetComponent<Collider>(), false);

    }
}
