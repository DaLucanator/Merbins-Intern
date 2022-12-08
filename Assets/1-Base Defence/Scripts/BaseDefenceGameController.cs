using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BaseDefenceGameController : MonoBehaviour
{
    public static BaseDefenceGameController current;

    [SerializeField] GameObject enemyPortal;
    BaseDefenseEnemySpawner enemySpawner;

    [SerializeField] Transform[] portal1;
    [SerializeField] Transform[] portal2;
    [SerializeField] Transform[] waypoints;


    public List<GameObject> allEnemies = new List<GameObject>();

    private bool portalIsActive;

    void Awake()
    {
        current = this;

        StartCoroutine(LevelTimer());
    }

    private void Start()
    {
        enemySpawner = enemyPortal.GetComponent<BaseDefenseEnemySpawner>();
    }

    public void ActivateEnemyPortal()
    {
        if (!portalIsActive) { enemyPortal.SetActive(true); }
        
        portalIsActive = true;
    }

    public void DeActivateEnemyPortal()
    {
        enemyPortal.SetActive(false);
    }

    public Transform GetPortal2Transform()
    {
        return portal2[Random.Range(0, portal2.Length)];
    }

    public Transform GetPortal1Transform(Transform transformToCompare)
    {
        Transform tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transformToCompare.position;
        foreach (Transform t in portal1)
        {
            float dist = Vector3.Distance(t.position, currentPos);
            if (dist < minDist)
            {
                tMin = t;
                minDist = dist;
            }
        }
        return tMin;
    }

    public Transform[] GetEnemyWaypoints()
    {
        return waypoints;
    }

    private IEnumerator LevelTimer()
    {
        yield return new WaitForSeconds(30f);
        ActivateEnemyPortal();

        //easy to start 5
        yield return new WaitForSeconds(15f);

        //first wave 3
        enemySpawner.SetSpawnDelay(5f);
        yield return new WaitForSeconds(45f);

        //second wave 1
        enemySpawner.SetSpawnDelay(1f);
        yield return new WaitForSeconds(45f);

        //the finale 0.5
        enemySpawner.SetSpawnDelay(0.5f);
        yield return new WaitForSeconds(60f);

        //final outburts 0.1
        enemySpawner.SetSpawnDelay(0.1f);
        yield return new WaitForSeconds(5f);

        DeActivateEnemyPortal();
    }



}
