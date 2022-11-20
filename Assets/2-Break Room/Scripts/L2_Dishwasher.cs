using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L2_Dishwasher : MonoBehaviour
{
    [SerializeField] int i_washQuantity;
    [SerializeField] L2_CleaningManager cM;
    List<GameObject> cleanedObjects = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out L2_Washable washable))
        {
            i_washQuantity--;
            cleanedObjects.Add(other.gameObject);
            washable.doneParticles();
            other.GetComponent<PickupObjective>().canTurnOn = false;

            if (i_washQuantity <= 0)
            {
                //thing is done
                cM.FinishTask(2);
                //close door
                //destroy all objects
                foreach (GameObject obj in cleanedObjects)
                {
                    //obj.GetComponent<PickupObjective>().switchActiveTo(false);
                    Destroy(obj);
                }
                
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        

        if (other.gameObject.GetComponent<L2_Washable>())
        {
            cleanedObjects.Remove(other.gameObject);
            i_washQuantity++;
            other.GetComponent<PickupObjective>().canTurnOn = true;
        }
    }




}
