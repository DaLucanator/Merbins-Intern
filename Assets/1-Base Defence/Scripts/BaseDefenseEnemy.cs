using System.Collections;
using System.Collections.Generic;
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

    public bool CheckIfRagdoll()
    {
        return isRagdoll;
    }


    //attack the crystal
}
