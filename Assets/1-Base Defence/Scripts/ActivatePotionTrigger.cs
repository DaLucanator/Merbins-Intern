using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePotionTrigger : MonoBehaviour
{

    /* void OntriggerEnter(Collider collider)
     {
         if(collider.gameObject.GetComponent<BaseDefencePotion>()!= null )
         {
             collider.gameObject.GetComponent<BaseDefencePotion>().ActivatePotion();
         }

         Debug.Log("boop");
     }*/

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<BaseDefencePotion>() != null)
        {
            other.gameObject.GetComponent<BaseDefencePotion>().ActivatePotion();
        }
        Debug.Log("boop");
    }
}
