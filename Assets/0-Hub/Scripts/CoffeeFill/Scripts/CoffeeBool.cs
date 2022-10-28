using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeBool : MonoBehaviour
{
    public bool checkBool;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<CoffeeContainer>())
        {
            checkBool = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<CoffeeContainer>())
        {
            checkBool = false;
        }
    }
}
