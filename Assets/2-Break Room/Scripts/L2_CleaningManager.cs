using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L2_CleaningManager : MonoBehaviour
{
    /*[Header("Dependencies")]

    [SerializeField] L2_Bin RubbishManager;
    [SerializeField] L2_SpongeScript FilthManager;*/


    [Header("Cleaning tasks")]
    [SerializeField] bool filth;
    [SerializeField] bool garbage;
    [SerializeField] bool dishes;
    [SerializeField] bool food;
    [SerializeField] bool finished;
    public void FinishTask(int _task)
    {
        switch (_task)
        {
            case 0:
                filth = true;
                break;
            case 1:
                garbage = true;
                break;
            case 2:
                dishes = true;
                break;
            case 3:
                food = true;
                break;
        }
        //tick off _task from clipboard;
        if (filth && garbage && dishes && food)
        {
            //tasks are done
            // win
            //allow remodeling
            finished = true;
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
