using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L2_FoodManager : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] int i_foodObjectives;
    [SerializeField] L2_CleaningManager cM;
    List<GameObject> doneFood = new List<GameObject>();

    [SerializeField] L2_FoodObjective[] objectives;

    private void OnEnable()
    {
        foreach (L2_FoodObjective o in objectives)
        {
            o.fM = this;
        }
        i_foodObjectives = objectives.Length;
    }


    public void foodObj(GameObject obj, bool add)
    {
        if (add)
        {
            doneFood.Add(obj);
            i_foodObjectives--;
        }
        else
        {
            doneFood.Remove(obj);
            i_foodObjectives++;
        }
        if (i_foodObjectives <= 0)
        {
            //finish
            cM.FinishTask(3);
        }
    }

}
