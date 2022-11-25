using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDefenceComputer : MonoBehaviour
{
    [SerializeField] private GameObject[] potions;
    [SerializeField] private Transform potionSpawn;
    [SerializeField] private Color[] colors;
    [SerializeField] private GameObject screen;

    private Material screenMat;
    private int potionNum;

    private void Start()
    {
        screenMat = screen.GetComponent<Renderer>().material;
        screenMat.color = colors[potionNum];
    }
    public void RightButton()
    {
        potionNum++;
        if(potionNum >= potions.Length) { potionNum = 0; }
        screenMat.color = colors[potionNum];
    }

    public void LeftButton()
    {
        potionNum--;
        if(potionNum < 0) { potionNum = potions.Length - 1; }
        screenMat.color = colors[potionNum];
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
