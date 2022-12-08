using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDefenseEnemySpawner : MonoBehaviour
{
    [SerializeField] float spawnDelayBase;
    [SerializeField] GameObject enemyRagdoll;
    [SerializeField] Transform spawnPos;
    [SerializeField] private AudioSource spawnSound;

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

        spawnSound.Play();

        SpawnEnemy();
    }

    public void SetSpawnDelay(float amount)
    {
        spawnDelayBase = amount;
        spawnDelayRandomMod = spawnDelayBase / 2f;
    }

    public float GetSpawnDelayBase()
    {
        return spawnDelayBase;
    }


}
