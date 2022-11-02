using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BaseDefencePotion : MonoBehaviour
{
    [SerializeField] private float explosionForce, explosionForceUp, explosionRadius, explosionDamage, explosionScale;
    [SerializeField] private GameObject explosionObject;

    [SerializeField] private float lightningScale, lightningStrikeDistance;


    [SerializeField] private float crystalScale;
    [SerializeField] private GameObject crystalObject;

    [SerializeField] private float fearScale;
    [SerializeField] private GameObject fearObject;

    [SerializeField] private float portalScale;

    [SerializeField] private bool potionIsActive;

    [SerializeField] private GameObject goblinRagdoll;

    private void OnCollisionEnter(Collision collision)
    {
        if (potionIsActive)
        {
            SpawnExplosion();
        }
    }

    void SpawnExplosion()
    {
        GameObject newExplosionObject = Instantiate(explosionObject, transform.position, Quaternion.identity);
        BaseDefenseExplosion explosion = newExplosionObject.GetComponent<BaseDefenseExplosion>();

        float modifier = lightningScale + 1f;
        float modifier2 = (lightningScale + crystalScale + fearScale + portalScale) * explosionScale;

        explosion.SetExplosionForce(explosionForce + (explosionForce * modifier2));
        explosion.SetExplosionForceUp(explosionForceUp + (explosionForceUp * modifier2));
        explosion.SetExplosionRadius(explosionRadius + (explosionRadius * modifier2));
        explosion.SetExplosionDamage(explosionDamage + (explosionDamage * modifier2));
        explosion.SetExplosionObject(explosionObject);

        explosion.SetLightningScale(lightningScale -1f);
        explosion.SetlightningStrikeDistance(lightningStrikeDistance); ;

        explosion.SetCrystalScale(crystalScale);
        explosion.SetCrystalObject(crystalObject);

        explosion.SetFearScale(fearScale);
       // explosion.SetFearObject(fearObject);

       // explosion.SetGoblinRagdoll(goblinRagdoll);

        explosion.Explode();

        Destroy(gameObject);
    }

    void ActivatePotion()
    {
        potionIsActive = true;
    }
}
