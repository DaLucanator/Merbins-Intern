using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDefenceVFX : MonoBehaviour
{

    public void SetScale(float scale)
    {
        transform.localScale *= scale;
    }

    private void Start()
    {
       StartCoroutine( DestroyMe());
    }

    IEnumerator DestroyMe()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
}
