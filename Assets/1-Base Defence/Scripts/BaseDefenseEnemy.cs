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
        if(agent.remainingDistance < 0.1f && isProtester)
        {
            protesterNum++;
            if(protesterNum >= protesterTransforms.Length) { protesterNum = 0; }
            agent.SetDestination(protesterTransforms[protesterNum].position);
        }
        if (GetComponent<Rigidbody>().isKinematic == false && isProtester)
        {
            BaseDefenceGameController.current.ActivateEnemyPortal();
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
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

    public void Kill()
    {
        Destroy(gameObject);
    }

    private IEnumerator LightningStrikeTimer()
    {
        yield return new WaitForSeconds(1f);
        canBeStruckByLightning = true;
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
