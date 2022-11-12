using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : MonoBehaviour
{
    //var delay = 2.0;
    public GameObject Smoke;

    float count = 0f;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("DestrucTrigger"))
        {
            Destroy(collision.gameObject);
            count = count + 1;
            
        }
        Debug.Log(count);


    }
    
   
}
