using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class BaseDefenseCrystal : MonoBehaviour
{
    [SerializeField] private GameObject crystalRagdollObject;

    [SerializeField] private float explosionForce, explosionForceUp, explosionRadius, explosionDamage;
    [SerializeField] private GameObject explosionObject;

    [SerializeField] private GameObject lightningVFX;
    [SerializeField] private GameObject explosionVFX;

    [SerializeField] private float healthMod;
    private float maxHealth;
    private float currentHealth;

    private Material material;
    private Renderer[] renderers;

    private float crystalScale;

    private bool isActive;

    bool canTakeDamage = true;

    void Start()
    {
        material = new Material(Shader.Find("Standard"));
        renderers = gameObject.GetComponentsInChildren<Renderer>();

        foreach(Renderer r in renderers)
        {
            r.material = material;
            r.material.color = Random.ColorHSV();
        }

    }

    public void SetCrystaLScale(float num)
    {
        crystalScale = num;
        gameObject.transform.localScale *= crystalScale;

        maxHealth = healthMod * crystalScale;
        currentHealth = maxHealth;
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

    void LoseHealth()
    {
        currentHealth--;

        if (currentHealth <= 0f)
        {
            Explode();
        }
    }

    private IEnumerator TakeDamage()
    {
        canTakeDamage = false;

        foreach (GameObject enemy in BaseDefenceGameController.current.allEnemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if(distance < (transform.localScale.x * 3f))
            {
                LoseHealth();
            }
        }

        yield return new WaitForSeconds(1f);

        canTakeDamage = true;
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
