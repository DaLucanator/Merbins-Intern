using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BaseDefenseExplosion : MonoBehaviour
{
    private float explosionForce, explosionForceUp, explosionRadius, explosionDamage;
    private GameObject explosionObject;

    private float lightningScale, lightningStrikeDistance;
    
    private float crystalScale;
    private GameObject crystalObject;

    private float fearScale;
    private GameObject fearObject;

    private GameObject goblinRagdoll;

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
                rb.isKinematic = false;
                if (hit.gameObject.GetComponent<NavMeshAgent>() != null) { hit.gameObject.GetComponent<NavMeshAgent>().enabled = false; }
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
            GameObject newCrystal = Instantiate(crystalObject, transform.position, Quaternion.identity);
            BaseDefenseCrystal crystal = newCrystal.GetComponent<BaseDefenseCrystal>();
            crystal.SetCrystaLScale(crystalScale);
        }

        //Fear
        else if(fearScale > 0f)
        {
            GameObject newFear = Instantiate(fearObject, transform.position, Quaternion.identity);

            Collider[] colliders2 = Physics.OverlapSphere(transform.position, explosionRadius);
            foreach (Collider hit in colliders2)
            {
                if (hit.GetComponent<BaseDefenseEnemy>())
                {
                    hit.GetComponent<BaseDefenseEnemy>().InduceFear(fearScale);
                }
            }
        }

        //lightning Strike
        if (lightningScale > 0f)
        {
            Debug.Log("pew");
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
                Transform objectToHit = enemies[Random.Range(0, enemies.Count)].transform;

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

                explosion.SetGoblinRagdoll(goblinRagdoll);

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

    public void SetFearScale(float num)
    {
        fearScale = num;
    }

    public void SetFearObject(GameObject gameObject)
    {
        fearObject = gameObject;
    }

    public void SetGoblinRagdoll(GameObject gameobject)
    {
        goblinRagdoll = gameobject;
    }
}
