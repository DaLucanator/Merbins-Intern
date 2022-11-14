using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BaseDefensePortal : MonoBehaviour
{
    private BaseDefensePortal otherPortal;

    [SerializeField]
    private Transform spawnPos;

    private bool isActivated = false;

    public void SetPortalScale(float num)
    {
        gameObject.transform.localScale *= num;
    }

    public void SetOtherPortal(BaseDefensePortal portal)
    {
        otherPortal = portal;
    }

    public void Activate(float time, bool kill)
    {
        isActivated = true;
        StopAllCoroutines();
        StartCoroutine(WaitToDeactivate(time * 5f, kill));
    }

    public bool IsActivated()
    {
        return isActivated;
    }

    private IEnumerator WaitToDeactivate(float time, bool kill)
    {
        yield return new WaitForSeconds(time);
        isActivated = false;
        gameObject.SetActive(false);
        if (kill) { Destroy(gameObject); }
    }

    public BaseDefensePortal GetOtherPortal()
    {
        return otherPortal;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Rigidbody>() && collision.gameObject.GetComponent<BaseDefenseCrystal>() == null)
        {
            if (collision.gameObject.GetComponent<NavMeshAgent>() != null) { collision.gameObject.GetComponent<NavMeshAgent>().enabled = false; }
            collision.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
    }


    public Transform GetSpawnPos()
    {
        return spawnPos;
    }
}
