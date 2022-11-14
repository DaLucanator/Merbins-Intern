using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PotionDetector : MonoBehaviour
{
    [SerializeField] private PotionCombiner potionCombiner;
    [SerializeField] bool leftButton, rightButton;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<BaseDefencePotion>())
        {
            if (rightButton) { potionCombiner.SetPotion1(other.gameObject.GetComponent<BaseDefencePotion>()); }

            if (leftButton) { potionCombiner.SetPotion2(other.gameObject.GetComponent<BaseDefencePotion>()); }
        }
    }
}
