using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDefenseExplosion : MonoBehaviour
{
    private float explosionForce, explosionForceUp, explosionRadius, explosionDamage;
    private GameObject explosionObject;

    private float lightningScale, lightningStrikeDistance;
    
    private float crystalScale;
    private GameObject crystalObject;

    // Update is called once per frame
    public void Explode()
    {
        //Explosion
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            BaseDefenseEnemy enemy = hit.GetComponent<BaseDefenseEnemy>();

            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, explosionForceUp);
            }

            if (enemy != null)
            {
                enemy.TakeDamage(explosionDamage);
            }
        }

        //Spawn Crystal
        if (crystalScale > 0f)
        {
            Debug.Log(transform.position.ToString());
            GameObject newCrystal = Instantiate(crystalObject, transform.position, Quaternion.identity);
            BaseDefenseCrystal crystal = newCrystal.GetComponent<BaseDefenseCrystal>();
            crystal.SetCrystaLScale(crystalScale);
        }

        //lightning Strike
        if (lightningScale > 0f)
        {
            Debug.Log("kerchoo");

            lightningScale -= 1f;

            StartCoroutine(WaitForLightning());

            Collider[] colliders2 = Physics.OverlapSphere(transform.position, lightningStrikeDistance);
            List<GameObject> enemies = new List<GameObject>();
            foreach (Collider hit in colliders2)
            {
                if(hit.GetComponent<BaseDefenseEnemy>())
                {
                    if(hit.gameObject.GetComponent<BaseDefenseEnemy>().CheckifCanBeStruck())
                    {
                        enemies.Add(hit.gameObject);
                    }
                }
            }

            if(enemies.Count > 0)
            {
                Transform objectToHit = colliders2[Random.Range(0, enemies.Count)].transform;

                GameObject newExplosionObject = Instantiate(explosionObject, objectToHit.position, Quaternion.identity);
                BaseDefenseExplosion explosion = newExplosionObject.GetComponent<BaseDefenseExplosion>();

                explosion.SetExplosionForce(explosionForce);
                explosion.SetExplosionForceUp(explosionForceUp);
                explosion.SetExplosionRadius(explosionRadius);
                explosion.SetExplosionDamage(explosionDamage);
                explosion.SetExplosionObject(explosionObject);

                explosion.SetLightningScale(lightningScale);
                explosion.SetlightningStrikeDistance(lightningStrikeDistance);

                explosion.SetCrystalScale(crystalScale);
                explosion.SetCrystalObject(crystalObject);

                explosion.Explode();
            }
        }
    }

    IEnumerator WaitForLightning()
    {
        yield return new WaitForSeconds(0.2f);
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
}
