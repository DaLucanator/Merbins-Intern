using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDefenseEnemySpawner : MonoBehaviour
{
    [SerializeField] float spawnDelayBase;
    [SerializeField] GameObject enemyRagdoll;
    [SerializeField] Transform spawnPos;

    private float spawnDelayRandomMod;

    void Start()
    {
        SpawnEnemy();
    }

    void SpawnEnemy()
    {
        StopAllCoroutines();
        float spawnDelay = spawnDelayBase + Random.Range(-spawnDelayRandomMod, spawnDelayRandomMod);
        StartCoroutine(SpawnTimer(spawnDelay));
    }

    private IEnumerator SpawnTimer(float timeToWait)
    {
        yield return new WaitForSeconds(timeToWait);

        GameObject ragdollObject = Instantiate(enemyRagdoll,spawnPos.position, spawnPos.rotation);
        BaseDefenseRagdoll ragdoll = ragdollObject.GetComponent<BaseDefenseRagdoll>();

        ragdoll.Fling();

        SpawnEnemy();
    }

    public void ReduceSpawnDelay(float reduceAmount)
    {
        spawnDelayBase -= reduceAmount;
        spawnDelayRandomMod = spawnDelayBase / 2f;
    }

    public float GetSpawnDelayBase()
    {
        return spawnDelayBase;
    }


}
