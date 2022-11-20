using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L2_FoodObjective : MonoBehaviour
{
    public L2_FoodManager fM;
    [SerializeField] GameObject objective;

    [SerializeField] GameObject donePrefab;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<L2_FoodItem>())
        {
            fM.foodObj(other.gameObject, true);
            other.GetComponent<PickupObjective>().canTurnOn = false;
            
            visibility(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<L2_FoodItem>())
        {
            fM.foodObj(other.gameObject,false);
            other.GetComponent<PickupObjective>().canTurnOn = true;
            visibility(true);
        }
    }

    void visibility(bool v)
    {
        gameObject.transform.GetChild(0).GetChild(0).gameObject.active = v;
        if (!v)
        {
            //particle effect
            Instantiate(donePrefab, transform.position, Quaternion.identity);
        }

    }



}
