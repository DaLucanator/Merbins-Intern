using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillDrop : MonoBehaviour
{
    public CoffeeSpill coffeeSpill;
    public List<CoffeeBool> coffeeCollider;
    public float speed = 1f;

    public bool allTrue = false;

    void FixedUpdate()
    {
        foreach (CoffeeBool item in coffeeCollider)
        {
            if (item.checkBool)
            {
                allTrue = true;
            }
            else
            {
                allTrue = false;
                break;
            }
        }

        if (allTrue == false)
        {
            coffeeSpill.coffee = Mathf.Lerp(coffeeSpill.coffee, 0, Time.deltaTime * speed);
        }
    }
}
