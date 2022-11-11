using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeMachine : MonoBehaviour
{
    public GameObject coffeeJar;
    public CoffeeSpill coffeeSpill;
    public FillDrop fillDrop;

    public Transform point;

    public float speed = 1f;
    bool addfillCoffee;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<CoffeeContainer>())
        {
            coffeeJar = other.gameObject.transform.parent.gameObject;
            coffeeSpill = coffeeJar.transform.GetChild(2).gameObject.GetComponent<CoffeeSpill>();
            fillDrop = coffeeJar.transform.GetChild(2).gameObject.GetComponent<FillDrop>();

            coffeeJar.transform.position = point.transform.position;
            coffeeJar.transform.rotation = Quaternion.identity;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<CoffeeContainer>())
        {
            coffeeJar = null;
            coffeeSpill = null;
            fillDrop = null;
        }
    }

    private void Update()
    {
        if (coffeeJar != null)
        {
            if (coffeeJar.transform.up.y > 0.95f)
            {
                if (addfillCoffee == true)
                {
                    coffeeSpill.coffee = Mathf.Lerp(coffeeSpill.coffee, 1, Time.deltaTime * speed);

                    fillDrop.enabled = false;
                }
                else
                {
                    fillDrop.enabled = true;
                }
            }
            else
            {
                fillDrop.enabled = true;
            }
        }
    }

    public void FillGo()
    {
        addfillCoffee = true;
    }
    public void FillStop()
    {
        addfillCoffee = false;
    }
}
