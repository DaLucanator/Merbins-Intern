using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class L2_RemodelData : MonoBehaviour
{
    [SerializeField]
    int[] objectsMaterials =
    {
        0, //Obj0
        0, //Obj1
        0, //Obj2
        0, //Obj3
        0, //Obj4
        0, //Obj5
        0, //Obj6
        0, //Obj7
        0, //Obj8
        0, //Obj9
        0, //Obj10
        0, //Obj11
        0, //Obj12
        0, //Obj13
        0, //Obj14
        0, //Obj15
        0, //Obj16
        0  //Obj17
    };

    private void OnEnable()
    {
        GameObject existingObj = GameObject.FindGameObjectWithTag("L2_RemodelData");
        if (existingObj == null)
        {
            DontDestroyOnLoad(gameObject);
            gameObject.tag = "L2_RemodelData";
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public int savedMaterial(int id)
    {
        return objectsMaterials[id];
    }
    public void saveMaterial(int id, int value)
    {
        objectsMaterials[id] = value;
    }

}
