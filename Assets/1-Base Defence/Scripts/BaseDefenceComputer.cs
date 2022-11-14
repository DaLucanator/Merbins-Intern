using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDefenceComputer : MonoBehaviour
{
    [SerializeField] private GameObject[] potions;
    [SerializeField] private Transform potionSpawn;
    private int potionNum;

    public void RightButton()
    {
        potionNum++;
        if(potionNum >= potions.Length) { potionNum = 0; }
    }

    public void LeftButton()
    {
        potionNum--;
        if(potionNum < 0) { potionNum = potions.Length - 1; }
    }

    public void EnterButton()
    {
        PrintPotion(potions[potionNum]);
    }

    public void PrintPotion (GameObject potionToPrint)
    {
        Instantiate(potionToPrint, potionSpawn.position, Quaternion.identity);
    }
}
