using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L2_FoodObjective : MonoBehaviour
{
    public L2_FoodManager fM;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<L2_FoodItem>())
        {
            fM.foodObj(other.gameObject, true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<L2_FoodItem>())
        {
            fM.foodObj(other.gameObject,false);
        }
    }

}
