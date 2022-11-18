using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using UnityEngine.InputSystem.Android;

public class CrystalRagdoll : MonoBehaviour
{
    [SerializeField] private float explosionForce, explosionForceUp, explosionRadius, explosionDamage;
    [SerializeField] private GameObject explosionObject;

    private float crystalScale;
    [SerializeField] private GameObject crystalObject;

    private bool isActive;

    public void Activate()
    {

        StartCoroutine(WaitToActivate());
    }

    private IEnumerator WaitToActivate()
    {
        yield return new WaitForSeconds(1f);
        isActive = true;
    }

    public void SetCrystaLScale(float num)
    {
        crystalScale = num;
        gameObject.transform.localScale *= num;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<BaseDefenseGround>() && isActive)
        {

            GameObject newExplosionObject = Instantiate(explosionObject, collision.GetContact(0).point, Quaternion.identity);
            BaseDefenseExplosion explosion = newExplosionObject.GetComponent<BaseDefenseExplosion>();

            explosion.SetExplosionForce(explosionForce + (explosionForce * crystalScale));
            explosion.SetExplosionForceUp(explosionForceUp + (explosionForceUp * crystalScale));
            explosion.SetExplosionRadius(explosionRadius + (explosionRadius * crystalScale));
            explosion.SetExplosionDamage(explosionDamage + (explosionDamage * crystalScale));
            explosion.SetExplosionObject(explosionObject);

            explosion.SetCrystalScale(crystalScale);
            explosion.SetCrystalObject(crystalObject);

            explosion.Explode();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
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

    public void SetCrystalObject(GameObject gameObject)
    {
        crystalObject = gameObject;
    }
}