using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L2_SelfDestroy : MonoBehaviour
{
    [SerializeField] float fuse;
    
    private void FixedUpdate()
    {
        fuse -= Time.deltaTime;
        if (fuse <= 0)
        {
            Destroy(gameObject);
        }
    }
}
