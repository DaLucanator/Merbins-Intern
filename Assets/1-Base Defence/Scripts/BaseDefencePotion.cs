using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;

public class BaseDefensePotion : MonoBehaviour
{
    [SerializeField] private float explosionForce, explosionForceUp, explosionRadius, explosionDamage;
    [SerializeField] private GameObject explosionObject;

    [SerializeField] private float lightningScale, lightningStrikeDistance;


    [SerializeField] private float crystalScale;
    [SerializeField] private GameObject crystalObject;

    [SerializeField] private float fearScale;

    [SerializeField] private float portalScale;

    [SerializeField] private bool potionIsActive;

    private void OnCollisionEnter(Collision collision)
    {
        if (potionIsActive)
        {
            
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

        explosion.SetLightningScale(lightningScale);
        explosion.SetlightningStrikeDistance(lightningStrikeDistance);

        explosion.SetCrystalScale(crystalScale / modifier);
        explosion.SetCrystalObject(crystalObject);

        explosion.Explode();
    }

    void ActivatePotion()
    {
        potionIsActive = true;
    }
}
