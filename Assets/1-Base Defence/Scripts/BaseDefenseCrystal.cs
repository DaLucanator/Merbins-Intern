using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class BaseDefenseCrystal : MonoBehaviour
{
    [SerializeField] private float health = 5f;
    [SerializeField] private GameObject crystalRagdollObject;

    private float explosionForce, explosionForceUp, explosionRadius, explosionDamage;
    private GameObject explosionObject;

    private float crystalScale;
    private GameObject crystalObject;

    private bool isActive;

    public void SetCrystaLScale(float num)
    {
        gameObject.transform.localScale *= num;
        health *= num;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }

    public void Activate()
    {
        isActive = true;
        // activate a random mesh
    }

    //if I collide with a portal
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<BaseDefensePortal>() && isActive)
        {
            GameObject newCrystalRagdollObject = Instantiate(crystalRagdollObject, transform.position, Quaternion.identity);
            CrystalRagdoll crystalRagdoll = newCrystalRagdollObject.GetComponent<CrystalRagdoll>();

            crystalRagdoll.SetExplosionForce(explosionForce);
            crystalRagdoll.SetExplosionForceUp(explosionForceUp);
            crystalRagdoll.SetExplosionRadius(explosionRadius);
            crystalRagdoll.SetExplosionDamage(explosionDamage);
            crystalRagdoll.SetExplosionObject(explosionObject);

            crystalRagdoll.SetCrystalScale(crystalScale);
            crystalRagdoll.SetCrystalObject(crystalObject);

            crystalRagdoll.Activate();

            Destroy(gameObject);
        }
    }

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
