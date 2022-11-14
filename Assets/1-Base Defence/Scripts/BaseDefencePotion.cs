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

    [SerializeField] private float portalScale;
    [SerializeField] private GameObject portalObject;
    [SerializeField] private GameObject portal2Object;

    [SerializeField] private bool potionIsActive;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<BaseDefensePortal>() == null && collision.gameObject.GetComponent<BaseDefenseGround>())
        {
            SpawnExplosion(collision.GetContact(0).point);
        }
    }

    void SpawnExplosion(Vector3 point)
    {
        GameObject newExplosionObject = Instantiate(explosionObject, point, Quaternion.identity);
        BaseDefenseExplosion explosion = newExplosionObject.GetComponent<BaseDefenseExplosion>();

        float modifier = lightningScale + 1f;
        float modifier2 = (lightningScale + crystalScale + portalScale) * explosionScale;

        explosion.SetExplosionForce(explosionForce + (explosionForce * modifier2));
        explosion.SetExplosionForceUp(explosionForceUp + (explosionForceUp * modifier2));
        explosion.SetExplosionRadius(explosionRadius + (explosionRadius * modifier2));
        explosion.SetExplosionDamage(explosionDamage + (explosionDamage * modifier2));
        explosion.SetExplosionObject(explosionObject);

        explosion.setPortalScale(portalScale);
        explosion.SetPortalObject(portalObject);
        explosion.SetPortal2Object(portal2Object);

        explosion.SetLightningScale(lightningScale);
        explosion.SetlightningStrikeDistance(lightningStrikeDistance); ;

        explosion.SetCrystalScale(crystalScale);
        explosion.SetCrystalObject(crystalObject);

        explosion.Explode();

        Destroy(gameObject);
    }

    public void ActivatePotion()
    {
        potionIsActive = true;
    }
}
