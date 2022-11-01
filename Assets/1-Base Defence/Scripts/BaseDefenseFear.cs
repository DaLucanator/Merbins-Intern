using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDefenseFear : MonoBehaviour
{
    public void SetFearScale(float num)
    {
        gameObject.transform.localScale *= num;
    }
}
