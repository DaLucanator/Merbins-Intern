using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using UnityEngine.InputSystem.Android;

public class CrystalRagdoll : MonoBehaviour
{
    private float explosionForce, explosionForceUp, explosionRadius, explosionDamage;
    private GameObject explosionObject;

    private float crystalScale;
    private GameObject crystalObject;

    private bool isActive;

    public void Activate()
    {
        isActive = true;
        // activate a random mesh
    }

    public void SetRagDollScale(Vector3 scale)
    {
        gameObject.transform.localScale = scale;
    }

    //when I collide with ground spawn an explosion

    public void SetExplosionForce(float num)
    {
        explosionForce = num;
    }

    public void SetExplosionForceUp(float num)
    {
        explosionForceUp = num;
    }

    public void SetExplosionRadius(float num)
    {
        explosionRadius = num;
    }

    public void SetExplosionDamage(float num)
    {
        explosionForceUp = num;
    }

    public void SetExplosionObject(GameObject gameObject)
    {
        explosionObject = gameObject;
    }

    public void SetCrystalScale(float num)
    {
        crystalScale = num;
    }

    public void SetCrystalObject(GameObject gameObject)
    {
        crystalObject = gameObject;
    }
}
