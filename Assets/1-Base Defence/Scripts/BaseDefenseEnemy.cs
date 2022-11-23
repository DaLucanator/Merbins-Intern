using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class BaseDefenseEnemy : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private float randomSpeedMod;
    [SerializeField] private Transform portalLocation, crystalLocation;

    private NavMeshAgent agent;

    private Animator animator;

    private bool canBeStruckByLightning = true;
    private bool isRagdoll;

    private bool canAttack = true;

    [SerializeField] bool isProtester;
    [SerializeField] Transform[] protesterTransforms;
    [SerializeField] private int protesterNum;

    private void Start()
    {
        crystalLocation = GameObject.Find("Crystal Location").transform;
        float randNum = Random.Range(-randomSpeedMod, randomSpeedMod);
        agent = gameObject.GetComponent<NavMeshAgent>();
        agent.SetDestination(crystalLocation.position);

        float startSpeed = agent.speed;
        agent.speed += randNum;

        animator = gameObject.GetComponent<Animator>();
        animator.speed += animator.speed * (randNum/startSpeed);

        if(isProtester)
        {
            agent.SetDestination(protesterTransforms[protesterNum].position);
        }
    }

    private void Update()
    {
        if(GetComponent<Rigidbody>().isKinematic == true && isProtester)
        {
            if(agent.remainingDistance < 0.1f)
            {
                protesterNum++;
                if (protesterNum >= protesterTransforms.Length) { protesterNum = 0; }
                agent.SetDestination(protesterTransforms[protesterNum].position);
            }

        }
        if (GetComponent<Rigidbody>().isKinematic == false && isProtester)
        {
            BaseDefenceGameController.current.ActivateEnemyPortal();
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        StartCoroutine(DestroyMe());
    }

    IEnumerator DestroyMe()
    {
        yield return new WaitForSeconds(10f);
        Destroy(gameObject);
    }

    public void LightningStrike()
    {
        canBeStruckByLightning = false;
        StartCoroutine(LightningStrikeTimer());
    }

    public bool CheckifCanBeStruck()
    {
        return canBeStruckByLightning;
    }


    private IEnumerator LightningStrikeTimer()
    {
        yield return new WaitForSeconds(1f);
        canBeStruckByLightning = true;
    }



    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.GetComponent<BaseDefenseCrystal>())
        {
            agent.enabled = false;
            StartCoroutine(AttackCrystal(collision.gameObject.GetComponent<BaseDefenseCrystal>()));
        }
    }

    private IEnumerator AttackCrystal(BaseDefenseCrystal crystalToAttack)
    {
        if(canAttack)
        {
            canAttack = false;
            yield return new WaitForSeconds(1f);
            crystalToAttack.TakeDamage(1f);
            canAttack = true;
        }

    }

    public bool CheckIfRagdoll()
    {
        return isRagdoll;
    }


    //if I'm close enough to a crystal
    //cancel my navigation
    //attack the crystal


}
