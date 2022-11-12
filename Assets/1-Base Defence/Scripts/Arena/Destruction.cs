using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : MonoBehaviour
{
    //var delay = 2.0;
    public GameObject Smoke;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("DestrucTrigger"))
        {
            Destroy(collision.gameObject);
        }


    }
    
   
}
