using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L2_FoodObjective : MonoBehaviour
{
    public L2_FoodManager fM;
    [SerializeField] MeshRenderer[] meshes;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<L2_FoodItem>())
        {
            fM.foodObj(other.gameObject, true);
            visibility(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<L2_FoodItem>())
        {
            fM.foodObj(other.gameObject,false);
            visibility(true);
        }
    }

    void visibility(bool v)
    {
        foreach(MeshRenderer mesh in meshes)
        {
            mesh.enabled = v;
        }
        if (!v)
        {
            //particle effect
        }
    }



}
