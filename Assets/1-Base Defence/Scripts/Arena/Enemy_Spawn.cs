using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawn : MonoBehaviour
{

    public GameObject G0_Enemy;
    public float spawnTime = 2.0f;

    // Start is called before the first frame update

    void Start()
    {
        InstantiateEnemy();
    }

    void InstantiateEnemy()
    {
        GameObject G0_Current = (GameObject)Instantiate(G0_Enemy);
        G0_Current.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        if (spawnTime > -155)
        {
            StartCoroutine("waitForFewSeconds");
        }
        else
        {
            Debug.Log("EnD");
        }
        

    }

    IEnumerator waitForFewSeconds()
    {
        yield return new WaitForSeconds(spawnTime);
        InstantiateEnemy();
        spawnTime = spawnTime - 0.3f;
        Debug.Log(spawnTime);
    }


}
