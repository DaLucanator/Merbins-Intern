using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class L2_CleaningManager : MonoBehaviour
{
    [Header("PickupParticles")]

    [SerializeField] List<GameObject> PUObjs = new List<GameObject>();


    /*[Header("Dependencies")]

    [SerializeField] L2_Bin RubbishManager;
    [SerializeField] L2_SpongeScript FilthManager;*/


    [Header("Cleaning tasks")]
    [SerializeField] bool filth;
    [SerializeField] bool garbage;
    [SerializeField] bool dishes;
    [SerializeField] bool food;
    [SerializeField] bool finished;
    [Header("Prototype text objectives")]
    [SerializeField] GameObject objfilth;
    [SerializeField] GameObject objgarbage;
    [SerializeField] GameObject objdish;
    [SerializeField] GameObject objfood;
    [SerializeField] GameObject objfin;
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
        Done();
        



    }
    void Done()
    {
        GetComponent<AudioSource>().Play();
        objfilth.SetActive(!filth);
        objgarbage.SetActive(!garbage);
        objdish.SetActive(!dishes);
        objfood.SetActive(!food);
        objfin.SetActive(finished);

        foreach(GameObject obj in PUObjs)
        {
            if(obj.name != "Wand")
            {
                obj.GetComponent<PickupObjective>().controlAll(false);
            }
        }
    }

    public void otherActivityChange(GameObject from,bool used)
    {
        //Debug.Log(3);
        int reference = PUObjs.IndexOf(from);

        for (int i = 0; i<PUObjs.Count; i++)
        {
            PUObjs = GameObject.FindGameObjectsWithTag("L2_PickupManager").ToList<GameObject>();
            if (PUObjs[i] == null)
            {
                //PUObjs.RemoveAt(i);
                //Debug.Log("THIS IS NULL " + i);
                continue;
            }else if(reference != i)
            {
                //Debug.Log($"I am {gameObject.name} + im trying to get int {i} ");
                //Debug.Log($"I am {gameObject.name} + im trying to get int {i}, this is {PUObjs[i]} ");
                PUObjs[i].GetComponent<PickupObjective>().OtherUsed(used);
            }

        }
    }


    private void OnEnable()
    {


        PUObjs = GameObject.FindGameObjectsWithTag("L2_PickupManager").ToList<GameObject>();
        //Debug.Log(GameObject.FindGameObjectsWithTag("L2_PickupManager")[0]);
    }
}
