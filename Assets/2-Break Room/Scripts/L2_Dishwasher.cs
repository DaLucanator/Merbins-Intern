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

            if (i_washQuantity <= 0)
            {
                //thing is done
                cM.FinishTask(2);
                //close door
                //destroy all objects
                foreach (GameObject obj in cleanedObjects)
                {
                    Destroy(obj);
                }
                
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        cleanedObjects.Remove(other.gameObject);

        if (other.gameObject.GetComponent<L2_Rubbish>())
        {
            i_washQuantity++;
        }
    }




}
