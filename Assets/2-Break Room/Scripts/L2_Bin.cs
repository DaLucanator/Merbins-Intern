using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L2_Bin : MonoBehaviour
{
    [SerializeField] int i_RubbishQuantity;
    [SerializeField] L2_CleaningManager cM;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<L2_Rubbish>())
        {
            other.GetComponent<PickupObjective>().switchActiveTo(false);
            Destroy(other.gameObject);
            GetComponent<AudioSource>().Play();
            i_RubbishQuantity--;
            if (i_RubbishQuantity <= 0)
            {
                //thing is done
                cM.FinishTask(1);

            }
        }
    }
}
