using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : MonoBehaviour
{

    public AudioSource Death_Goblin;

    float count = 0f;

    public bool off;

    void OnCollisionEnter(Collision collision)
    {
        if (off != true)
        {
            if (collision.gameObject.tag.Equals("DestrucTrigger"))
            {

                Destroy(collision.gameObject);
                Death_Goblin.Play();
                count = count + 1;

            }

            Debug.Log(count);
        }
    }
    
   
}
