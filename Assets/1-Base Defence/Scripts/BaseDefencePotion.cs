using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDefencePotion : MonoBehaviour
{
    [SerializeField] private float explosionForce, explosionForceUp, explosionRadius, explosionDamage;
    [SerializeField] private GameObject explosionObject;

    [SerializeField] private float lightningScale, lightningStrikeDistance;


    [SerializeField] private float crystalScale;
    [SerializeField] private GameObject crystalObject;

    [SerializeField] private float fearScale;
    [SerializeField] private GameObject fearObject;

    [SerializeField] private float portalScale;

    [SerializeField] private bool potionIsActive;

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
        float modifier2 = lightningScale + crystalScale + fearScale + portalScale;

        explosion.SetExplosionForce((explosionForce * modifier2) / modifier);
        explosion.SetExplosionForceUp((explosionForceUp * modifier2) / modifier);
        explosion.SetExplosionRadius((explosionRadius * modifier2) / modifier);
        explosion.SetExplosionDamage((explosionDamage * modifier2) / modifier);
        explosion.SetExplosionObject(explosionObject);

        explosion.SetLightningScale(lightningScale -1f);
        explosion.SetlightningStrikeDistance(lightningStrikeDistance);

        explosion.SetCrystalScale(crystalScale / modifier);
        explosion.SetCrystalObject(crystalObject);

        explosion.SetFearScale(fearScale / modifier);
        explosion.SetFearObject(fearObject);

        explosion.Explode();

        Destroy(gameObject);
    }

    void ActivatePotion()
    {
        potionIsActive = true;
    }
}
