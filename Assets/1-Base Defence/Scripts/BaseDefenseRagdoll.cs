using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDefenseRagdoll : MonoBehaviour
{
    [SerializeField] private GameObject[] enemy;

    [SerializeField] private float randomFlingForce, randomFlingTorque, randomFlingTorque2, getUpTimerMin, getUpTimerMax;

    private Quaternion rotation = Quaternion.Euler(0, 180, 0);

    public void Fling()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * Random.Range(0f,randomFlingForce));
        Vector3 rotateVector = new Vector3(Random.Range(-randomFlingTorque, randomFlingTorque), Random.Range(-randomFlingTorque2,randomFlingTorque2), Random.Range(-randomFlingTorque2, randomFlingTorque2));
        rb.AddTorque(rotateVector);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<BaseDefenseGround>())
        {
            StartCoroutine(GetUp());
        }
    }

    private IEnumerator GetUp()
    {
        yield return new WaitForSeconds(Random.Range(getUpTimerMin,getUpTimerMax));

        GameObject enemyObject = Instantiate(enemy[Random.Range(0,enemy.Length)], gameObject.transform.position, rotation);
        BaseDefenceGameController.current.allEnemies.Add(enemyObject);

        Destroy(gameObject);

        StopAllCoroutines();
    }

}
