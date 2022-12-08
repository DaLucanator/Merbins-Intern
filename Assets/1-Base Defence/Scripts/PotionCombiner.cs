using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionCombiner : MonoBehaviour
{
    private BaseDefencePotion potion1, potion2;

    [SerializeField] private Transform spawnPos;
    [SerializeField] private GameObject potion;

    [SerializeField] private GameObject rightLight, leftLight;
    [SerializeField] private Material redMat, greenMat;

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

        Potion1Null();
        Potion2Null();
    }

    public void SetPotion1 (BaseDefencePotion potion)
    {
        potion1 = potion;
        rightLight.GetComponent<Renderer>().material = greenMat;
    }

    public void SetPotion2 (BaseDefencePotion potion)
    {
        potion2 = potion;
        leftLight.GetComponent<Renderer>().material = greenMat;
    }

    public void Potion1Null()
    {
        rightLight.GetComponent<Renderer>().material = redMat;
        potion1 = null;
    }

    public void Potion2Null()
    {
        leftLight.GetComponent<Renderer>().material = redMat;
        potion2 = null;
    }
}
