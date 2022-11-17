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
        float modifier2 = crystalScale + portalScale;

        explosion.SetExplosionForce(explosionForce * modifier2);
        explosion.SetExplosionForceUp(explosionForceUp * modifier2);
        explosion.SetExplosionRadius(explosionRadius * modifier2);
        explosion.SetExplosionDamage(explosionDamage * modifier2);
        explosion.SetExplosionObject(explosionObject);

        explosion.setPortalScale(portalScale);
        explosion.SetPortalObject(portalObject);

        explosion.SetLightningScale(lightningScale);
        explosion.SetlightningStrikeDistance(lightningStrikeDistance); ;

        explosion.SetCrystalScale(crystalScale);
        explosion.SetCrystalObject(crystalObject);

        explosion.Explode();

        Destroy(gameObject);
    }

    public float GetCrystalScale()
    {
        return crystalScale;
    }
    public float GetLightningScale()
    {
        return lightningScale;
    }
    public float GetPortalScale()
    {
        return portalScale;
    }

    public void SetCrystalScale( float num)
    {
        crystalScale = num;
    }
    public void SetLightningScale(float num)
    {
        lightningScale = num;
    }
    public void SetPortalScale(float num)
    {
        portalScale = num;
    }

    public void ActivatePotion()
    {
        potionIsActive = true;
    }
}
