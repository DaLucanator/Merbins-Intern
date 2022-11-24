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

    [SerializeField] private GameObject lightningVFX;
    [SerializeField] private GameObject explosionVFX;

    private Material material;

    private Color potionColor,lightningColor,crystalColor,portalColor;
    private Renderer[] renderer;

    void Start()
    {
        material = new Material(Shader.Find("Standard"));

        renderer = gameObject.GetComponentsInChildren<Renderer>();

        renderer[0].material = material;

        lightningColor = Color.blue;
        crystalColor = Color.green;
        portalColor = Color.red;

        SetColor();
    }

    public void SetColor()
    {
        Color newcolor;
        newcolor = (lightningColor * lightningScale) + (crystalColor * crystalScale) + (portalColor * portalScale);
        newcolor /= lightningScale + crystalScale + portalScale;

        material.color = newcolor;
    }

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
        if (modifier2 <= 0f) { modifier2 = 1f; }

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

        explosion.SetLightningObject(lightningVFX);
        explosion.SetExplosionVFX(explosionVFX);

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
