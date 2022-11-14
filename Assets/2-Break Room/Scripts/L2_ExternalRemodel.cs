using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class L2_ExternalRemodel : MonoBehaviour
{
    [SerializeField] L2_Remodelable obj;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<L2_RemodelTool>())
        {
            obj.changeMaterial();
        }
    }


}
