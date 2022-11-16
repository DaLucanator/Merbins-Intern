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
        portalIsActive = false;
    }

    private IEnumerator LevelTimer()
    {
        yield return new WaitForSeconds(30f);
        ActivateEnemyPortal();

        float spawnDelayBase = enemySpawner.GetSpawnDelayBase();

        yield return new WaitForSeconds(21f);
        enemySpawner.ReduceSpawnDelay(spawnDelayBase / 10f);

        yield return new WaitForSeconds(21f);
        enemySpawner.ReduceSpawnDelay(spawnDelayBase / 10f);

        yield return new WaitForSeconds(21f);
        enemySpawner.ReduceSpawnDelay(spawnDelayBase / 10f);

        yield return new WaitForSeconds(21f);
        enemySpawner.ReduceSpawnDelay(spawnDelayBase / 10f);

        yield return new WaitForSeconds(21f);
        enemySpawner.ReduceSpawnDelay(spawnDelayBase / 10f);

        yield return new WaitForSeconds(21f);
        enemySpawner.ReduceSpawnDelay(spawnDelayBase / 10f);

        yield return new WaitForSeconds(21f);
        enemySpawner.ReduceSpawnDelay(spawnDelayBase / 10f);

        yield return new WaitForSeconds(21f);
        enemySpawner.ReduceSpawnDelay(spawnDelayBase / 10f);

        yield return new WaitForSeconds(21f);
        enemySpawner.ReduceSpawnDelay(spawnDelayBase / 10f);

        yield return new WaitForSeconds(21f);

        DeActivateEnemyPortal();
    }



}
