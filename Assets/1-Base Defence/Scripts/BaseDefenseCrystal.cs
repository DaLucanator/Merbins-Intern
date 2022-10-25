using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDefenseCrystal : MonoBehaviour
{
    [SerializeField] private float health = 5f; 

    public void SetCrystaLScale(float num)
    {
        gameObject.transform.localScale *= num;
        health *= num;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }
}
