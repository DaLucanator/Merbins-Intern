using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BaseDefenceGameController : MonoBehaviour
{
    public static BaseDefenceGameController current;

    [SerializeField] GameObject enemyPortal;
    BaseDefenseEnemySpawner enemySpawner;

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

    private IEnumerator LevelTimer()
    {
        yield return new WaitForSeconds(30f);
        ActivateEnemyPortal();

        float spawnDelayBase = enemySpawner.GetSpawnDelayBase();

        //easy to start 5

        //first wave 3

        //second wave 1

        //the finale 0.5

        //final outburts 0.1

        yield return new WaitForSeconds(21f);
        enemySpawner.ReduceSpawnDelay(spawnDelayBase / 4f);
        spawnDelayBase = enemySpawner.GetSpawnDelayBase();

        yield return new WaitForSeconds(21f);
        enemySpawner.ReduceSpawnDelay(spawnDelayBase / 4f);
        spawnDelayBase = enemySpawner.GetSpawnDelayBase();

        yield return new WaitForSeconds(21f);
        enemySpawner.ReduceSpawnDelay(spawnDelayBase / 4f);
        spawnDelayBase = enemySpawner.GetSpawnDelayBase();

        yield return new WaitForSeconds(21f);
        enemySpawner.ReduceSpawnDelay(spawnDelayBase / 4f);
        spawnDelayBase = enemySpawner.GetSpawnDelayBase();

        yield return new WaitForSeconds(21f);
        enemySpawner.ReduceSpawnDelay(spawnDelayBase / 3f);
        spawnDelayBase = enemySpawner.GetSpawnDelayBase();

        yield return new WaitForSeconds(21f);
        enemySpawner.ReduceSpawnDelay(spawnDelayBase / 3f);
        spawnDelayBase = enemySpawner.GetSpawnDelayBase();

        yield return new WaitForSeconds(21f);
        enemySpawner.ReduceSpawnDelay(spawnDelayBase / 3f);
        spawnDelayBase = enemySpawner.GetSpawnDelayBase();

        yield return new WaitForSeconds(21f);
        enemySpawner.ReduceSpawnDelay(spawnDelayBase / 2f);
        spawnDelayBase = enemySpawner.GetSpawnDelayBase();

        yield return new WaitForSeconds(21f);
        enemySpawner.ReduceSpawnDelay(spawnDelayBase / 1.5f);

        yield return new WaitForSeconds(21f);

        DeActivateEnemyPortal();
    }



}
