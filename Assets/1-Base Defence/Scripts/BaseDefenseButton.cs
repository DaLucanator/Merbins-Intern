using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDefenseButton : MonoBehaviour
{
    [SerializeField] private bool rightButton;
    [SerializeField] private bool leftButton;
    [SerializeField] private bool printButton;
    [SerializeField] private bool combineButton;

    [SerializeField] private BaseDefenceComputer computer;

    void OnTriggerEnter(Collider Collider)
    {
        if(Collider.CompareTag("Touch"))
        {
            if (rightButton) { computer.RightButton(); }

            if (leftButton) { computer.LeftButton(); }

            if (printButton) { computer.EnterButton(); }

            if (combineButton) { }
        }

    }
}
