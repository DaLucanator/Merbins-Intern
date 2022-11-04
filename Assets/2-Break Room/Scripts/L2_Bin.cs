using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L2_Bin : MonoBehaviour
{
    [SerializeField] int i_RubbishQuantity;
    [SerializeField] L2_CleaningManager cM;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<L2_Rubbish>())
        {
            Destroy(other.gameObject);
            i_RubbishQuantity--;
            if (i_RubbishQuantity <= 0)
            {
                //thing is done
                cM.FinishTask(1);

            }
        }
    }




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
