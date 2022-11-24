using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionCombiner : MonoBehaviour
{
    private BaseDefencePotion potion1, potion2;

    [SerializeField] private Transform spawnPos;
    [SerializeField] private GameObject potion;

    public void CreatePotion()
    {
        GameObject newPotionObject = Instantiate(potion, spawnPos.position, Quaternion.identity);
        BaseDefencePotion newPotion = newPotionObject.GetComponent<BaseDefencePotion>();

        newPotion.SetCrystalScale(potion1.GetCrystalScale() + potion2.GetCrystalScale());
        newPotion.SetLightningScale(potion1.GetLightningScale() + potion2.GetLightningScale());
        newPotion.SetPortalScale(potion1.GetPortalScale() + potion2.GetPortalScale());
        newPotion.SetColor();

        Destroy(potion1.gameObject);
        Destroy(potion2.gameObject);
    }

    public void SetPotion1 (BaseDefencePotion potion)
    {
        potion1 = potion;
    }

    public void SetPotion2 (BaseDefencePotion potion)
    {
        potion2 = potion;
    }
}
