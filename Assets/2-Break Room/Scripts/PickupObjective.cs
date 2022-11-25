using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObjective : MonoBehaviour
{
    [SerializeField] Vector3 lastPos;
    [SerializeField] float inUse  = -1;
    [SerializeField] float scale = 1;
    [SerializeField] bool was = false;
    //[SerializeField] Rigidbody rb;


    public bool canTurnOn = true;

    [SerializeField] GameObject[] showOnUse;
    [SerializeField] GameObject[] hideOnUse;
    List<GameObject> L_showOnUse = new List<GameObject>();
    List<GameObject> L_hideOnUse = new List<GameObject>();

    [SerializeField] bool showOn;

    public void OtherUsed(bool otherIsActive)
    {
        if (was||!canTurnOn)
            return;

        if (otherIsActive)
        {
            foreach (GameObject obj in showOnUse)
            {
                /*if(showOnUse == null)
                {
                    Debug.Log(gameObject);
                }*/
                obj.SetActive(false);
            }
            foreach (GameObject obj in hideOnUse)
            {
                obj.SetActive(false);
            }
        }
        else
        {
            foreach (GameObject obj in hideOnUse)
            {
                obj.SetActive(true);
            }
        }
    }

    private void Start()
    {
        //rb = GetComponent<Rigidbody>();
        lastPos = transform.position;

        L_showOnUse = new List<GameObject> (showOnUse);
        L_hideOnUse = new List<GameObject> (hideOnUse);

        switchActiveTo(false);
    }



    private void FixedUpdate()
    {
        if (inUse > 0)
        {

            inUse -= Time.deltaTime*2;
            if (!was)
            {
                //add time it has been like that


                inUse += 1;
                switchActiveTo(true);
                was = true;
            }
        }else if (was)
        {
            inUse -= 1;
            switchActiveTo(false);
            was = false;
        }
        inUse=Mathf.Clamp(inUse, -1, 1);
        

    }
    private void OnTriggerStay(Collider collision)
    {
        if (collision.CompareTag("Touch"))
        {
            inUse = 1;
            Debug.Log("REAL!");
        }
    }
    public void switchActiveTo(bool use)
    {
        //Debug.LogWarning($"{gameObject} WITHA CTIVITY " + use);
        if(canTurnOn || !use)
            GameObject.FindGameObjectWithTag("CleaningManager").GetComponent<L2_CleaningManager>().otherActivityChange(gameObject, use);
        //Debug.LogError(1);


        
        //Debug.LogError(2);
        foreach (GameObject obj in L_showOnUse)
        {
            if(obj!= null)
            {
                obj.SetActive(use);
            }
            else
            {
                L_showOnUse.Remove(obj);
            }
            
        }
        if (!canTurnOn&&!use)
            return;
        foreach (GameObject obj in L_hideOnUse)
        {
            if (obj != null)
            {
                obj.SetActive(!use);
            }else
            {
                L_hideOnUse.Remove(obj);
            }

        }
        
    }
    public void controlAll(bool to)
    {
        canTurnOn = to;

        foreach (GameObject obj in L_showOnUse)
        {
            if (obj != null)
            {
                obj.SetActive(to);
            }


        }

        foreach (GameObject obj in L_hideOnUse)
        {
            if (obj != null)
            {
                obj.SetActive(to);
            }
        }
    }


}
