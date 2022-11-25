using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.AI;

public class BaseDefenseExplosion : MonoBehaviour
{
    private float explosionForce, explosionForceUp, explosionRadius, explosionDamage;
    private GameObject explosionObject;

    private float portalScale;
    private GameObject portalObject;

    private float lightningScale, lightningStrikeDistance;
    
    private float crystalScale;
    private GameObject crystalObject;

    private GameObject lightningVFX;
    private GameObject explosionVFX;

    // Update is called once per frame
    public void Explode()
    {
        float modifier = portalScale + crystalScale;
        if (modifier <= 0f) { modifier = 1f; }

        GameObject explosionEffect = Instantiate(explosionVFX, transform.position, Quaternion.identity);
        explosionEffect.GetComponent<BaseDefenceVFX>().SetScale(modifier);

        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            BaseDefenseEnemy enemy = hit.GetComponent<BaseDefenseEnemy>();

            if (rb != null && hit.GetComponent<BaseDefenseCrystal>() == null && hit.GetComponent<DontRagdoll>() == null)
            {
                rb.isKinematic = false;
                if (hit.gameObject.GetComponent<NavMeshAgent>() != null) { hit.gameObject.GetComponent<NavMeshAgent>().enabled = false; }
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, explosionForceUp);
            }

            if (enemy != null)
            {
                Debug.Log("killing enemy");
                enemy.TakeDamage(explosionDamage);
            }
        }

        //Portal
        if (portalScale > 0)
        {
            Quaternion halfTurn = Quaternion.Euler(0f, 0f, 90f);   
            Vector3 spawnPos = new Vector3(101,15,15);

            Transform portal2Transform = BaseDefenceGameController.current.GetPortal2Transform();
            Transform portal1Transform = BaseDefenceGameController.current.GetPortal1Transform(gameObject.transform);

            GameObject portal2Object = Instantiate(portalObject, portal2Transform.position, portal2Transform.rotation);
            BaseDefensePortal portal2 = portal2Object.GetComponent<BaseDefensePortal>();

            GameObject portal1Object = Instantiate(portalObject, portal1Transform.position, portal1Transform.rotation);
            BaseDefensePortal portal1 = portal1Object.GetComponent<BaseDefensePortal>();



            portal2Object.SetActive(true);
            portal1Object.SetActive(true);
            portal1.SetPortalScale(portalScale);
            portal2.SetPortalScale(5f);

            portal1.SetOtherPortal(portal2);
            portal2.SetOtherPortal(portal1);

            portal2.Activate(portalScale, false);
            portal1.Activate(portalScale, true);
        }
        //instantiate the portal in the list of portals
        //remove that portal from the list of portals
        //add that portal back into the list of portals after portalscale time
        //activate portal2
        //activate portal


        //Spawn Crystal
        if (crystalScale > 0f)
        {
            GameObject newCrystal = Instantiate(crystalObject, transform.position, Quaternion.identity);
            BaseDefenseCrystal crystal = newCrystal.GetComponent<BaseDefenseCrystal>();

            crystal.SetCrystaLScale(crystalScale);

            crystal.Activate();
        }

        //lightning Strike
        if (lightningScale > 0f)
        {
            Debug.Log("pew");
            lightningScale -= 1f;

            Collider[] colliders2 = Physics.OverlapSphere(transform.position, lightningStrikeDistance);
            List<GameObject> enemies = new List<GameObject>();
            foreach (Collider hit in colliders2)
            {
                if (hit.GetComponent<BaseDefenseEnemy>())
                {
                    if (hit.gameObject.GetComponent<BaseDefenseEnemy>().CheckifCanBeStruck())
                    {
                        Debug.Log("pew2");
                        enemies.Add(hit.gameObject);
                    }
                }
            }

            if (enemies.Count > 0)
            {
                Transform objectToHit = enemies[Random.Range(0, enemies.Count)].transform;

                GameObject newExplosionObject = Instantiate(explosionObject, objectToHit.position, Quaternion.identity);
                BaseDefenseExplosion explosion = newExplosionObject.GetComponent<BaseDefenseExplosion>();

                explosion.SetExplosionForce(explosionForce);
                explosion.SetExplosionForceUp(explosionForceUp);
                explosion.SetExplosionRadius(explosionRadius);
                explosion.SetExplosionDamage(explosionDamage);
                explosion.SetExplosionObject(explosionObject);

                explosion.setPortalScale(portalScale);
                explosion.SetPortalObject(portalObject);

                explosion.SetLightningScale(lightningScale);
                explosion.SetlightningStrikeDistance(lightningStrikeDistance);

                explosion.SetCrystalScale(crystalScale);
                explosion.SetCrystalObject(crystalObject);

                explosion.SetLightningObject(lightningVFX);
                explosion.SetExplosionVFX(explosionVFX);

                Instantiate(lightningVFX, objectToHit.position, Quaternion.identity);
                StartCoroutine(WaitForLightning(explosion));
            }
        }

        else { StartCoroutine(DestroyMe()); }
    }

    IEnumerator WaitForLightning(BaseDefenseExplosion explosion)
    {
        yield return new WaitForSeconds(1f);
        explosion.Explode();

        Destroy(gameObject);
    }

    void DrawLine(Vector3 start, Vector3 end, Color color, float duration, float lineWidth)
    {
        GameObject myLine = new GameObject();
        myLine.transform.position = start;
        myLine.AddComponent<LineRenderer>();
        LineRenderer lr = myLine.GetComponent<LineRenderer>();
        lr.startColor = color;
        lr.endColor = color;
        lr.startWidth = lineWidth;
        lr.endWidth = lineWidth;
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
        GameObject.Destroy(myLine, duration);
    }

    IEnumerator DestroyMe()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
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

    public void setPortalScale(float num)
    {
        portalScale = num;
    }

    public void SetPortalObject(GameObject portal)
    {
        portalObject = portal;
    }

    public void SetLightningScale(float num)
    {
        lightningScale = num;
    }


    public void SetlightningStrikeDistance(float num)
    {
        lightningStrikeDistance = num;
    }

    public void SetCrystalScale(float num)
    {
        crystalScale = num;
    }

    public void SetCrystalObject(GameObject gameObject)
    {
        crystalObject = gameObject;
    }

    public void SetLightningObject(GameObject lightning)
    {
        lightningVFX = lightning;
    }

    public void SetExplosionVFX(GameObject vfx)
    {
        explosionVFX = vfx;
    }
}
