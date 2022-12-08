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

    [SerializeField] AudioSource protesterChant;

    [SerializeField] AudioSource[] flyingAudio;

    private NavMeshAgent agent;

    private Animator animator;

    private bool canBeStruckByLightning = true;
    private bool isRagdoll;

    [SerializeField] bool isProtester;
    [SerializeField] Transform[] protesterTransforms;
    [SerializeField] private int protesterNum;

    [SerializeField] Transform[] waypoints;
    private int waypointNum;

    private void Start()
    {
        waypoints = BaseDefenceGameController.current.GetEnemyWaypoints();

        waypointNum = Random.Range(0, 2);

        float randNum = Random.Range(-randomSpeedMod, randomSpeedMod);
        agent = gameObject.GetComponent<NavMeshAgent>();

        float startSpeed = agent.speed;
        agent.speed += randNum;

        animator = gameObject.GetComponent<Animator>();
        animator.speed += animator.speed * (randNum/startSpeed);

        agent.SetDestination(waypoints[waypointNum].position);

        if (isProtester)
        {
            agent.SetDestination(protesterTransforms[protesterNum].position);
        }
    }

    private void Update()
    {
        if(GetComponent<Rigidbody>().isKinematic == true && isProtester)
        {
            if(agent.remainingDistance < 0.5f)
            {
                protesterNum++;
                if (protesterNum >= protesterTransforms.Length) { protesterNum = 0; }
                agent.SetDestination(protesterTransforms[protesterNum].position);
            }

        }
        if (GetComponent<Rigidbody>().isKinematic == false && isProtester)
        {
            BaseDefenceGameController.current.ActivateEnemyPortal();
            protesterChant.Pause();
        }

        if (GetComponent<Rigidbody>().isKinematic == true && !isProtester && waypointNum !=4 )
        {
            if (agent.remainingDistance < 0.5f)
            {
                if (waypointNum <= 1) { waypointNum = Random.Range(2, 4); }
                else { waypointNum = 4; }

                agent.SetDestination(waypoints[waypointNum].position);
            }
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        BaseDefenceGameController.current.allEnemies.Remove(gameObject);

        int randInt = Random.Range(0, flyingAudio.Length);

        flyingAudio[randInt].Play();

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


    public bool CheckIfRagdoll()
    {
        return isRagdoll;
    }


    //if I'm close enough to a crystal
    //cancel my navigation
    //attack the crystal


}
