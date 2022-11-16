using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootZ : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("DestrucTrigger"))
        {
            collision.gameObject.GetComponent<RagdollZ>().Button = true;
            //collision.gameObject.GetComponent<ImpactZ>().Button = true;
        }
    }
}
