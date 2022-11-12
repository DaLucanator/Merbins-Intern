using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawn : MonoBehaviour
{

    public GameObject G0_Enemy;
    public float spawnTime = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        InstantiateEnemy();
    }

    void InstantiateEnemy()
    {
        GameObject G0_Current = (GameObject)Instantiate(G0_Enemy);
        G0_Current.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        StartCoroutine("waitForFewSeconds");

    }

    IEnumerator waitForFewSeconds()
    {
        yield return new WaitForSeconds(spawnTime);
        InstantiateEnemy();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
