using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class BaseDefenseCrystal : MonoBehaviour
{
    [SerializeField] private float health = 5f;
    [SerializeField] private GameObject crystalRagdollObject;

    [SerializeField] private float explosionForce, explosionForceUp, explosionRadius, explosionDamage;
    [SerializeField] private GameObject explosionObject;

    [SerializeField] private GameObject lightningVFX;
    [SerializeField] private GameObject explosionVFX;

    private float crystalScale;

    private bool isActive;

    bool canTakeDamage = true;

    public void SetCrystaLScale(float num)
    {
        crystalScale = num;
        gameObject.transform.localScale *= crystalScale;
        health *= num;
    }

    public void Activate()
    {
        isActive = true;
        // activate a random mesh
    }

    private void Update()
    {
        if(canTakeDamage)
        {
            StartCoroutine(TakeDamage());
        }
    }

    void Explode()
    {
        if(health <= 0f)
        {
            GameObject newExplosionObject = Instantiate(explosionObject, transform.position, Quaternion.identity);
            BaseDefenseExplosion explosion = newExplosionObject.GetComponent<BaseDefenseExplosion>();

            explosion.SetExplosionForce(explosionForce * crystalScale);
            explosion.SetExplosionForceUp(explosionForceUp * crystalScale);
            explosion.SetExplosionRadius(explosionRadius * crystalScale);
            explosion.SetExplosionDamage(explosionDamage * crystalScale);
            explosion.SetExplosionObject(explosionObject);

            explosion.SetLightningObject(lightningVFX);
            explosion.SetExplosionVFX(explosionVFX);

            explosion.Explode();
            Destroy(gameObject);
        }
    }

    void LoseHealth()
    {
        health--;
    }

    private IEnumerator TakeDamage()
    {
        canTakeDamage = false;

        foreach (GameObject enemy in BaseDefenceGameController.current.allEnemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if(distance > transform.localScale.x + 0.5f)
            {
                LoseHealth();
            }



            yield return new WaitForSeconds(1f);

            canTakeDamage=true;
        }
    }


    //if I collide with a portal
    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("spawning ragdoll");
        if (collider.gameObject.GetComponent<BaseDefensePortal>() && isActive)
        {
            isActive = false;
            Vector3 offsetVector = new Vector3(0, 5f, 0);
            GameObject newCrystalRagdollObject = Instantiate(crystalRagdollObject, collider.gameObject.transform.position + offsetVector, Quaternion.identity);
            CrystalRagdoll crystalRagdoll = newCrystalRagdollObject.GetComponent<CrystalRagdoll>();

            crystalRagdoll.SetCrystaLScale(crystalScale);

            crystalRagdoll.Activate();

            Destroy(gameObject);
        }
    }
}
