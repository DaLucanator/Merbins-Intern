using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    public Transform GetSpawnPos()
    {
        return spawnPos;
    }
}
