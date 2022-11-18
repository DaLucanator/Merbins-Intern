using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObjective : MonoBehaviour
{
    Vector3 lastPos;
    float inUse;
    bool wasinUse;
    



    [SerializeField] GameObject[] showOnActive;
    [SerializeField] GameObject[] hideOnActive;
    [SerializeField] bool showOn;

    public void OtherUsed(bool otherIsActive)
    {
        if (otherIsActive)
        {
            foreach (GameObject obj in showOnActive)
            {
                obj.SetActive(false);
            }
            foreach (GameObject obj in hideOnActive)
            {
                obj.SetActive(false);
            }
        }
        else
        {
            foreach (GameObject obj in hideOnActive)
            {
                obj.SetActive(true);
            }
        }
    }

    private void OnEnable()
    {
        lastPos = transform.position; 
    }



    private void FixedUpdate()
    {
        if (lastPos != transform.position)
        {
            inUse += Time.deltaTime;
            if (inUse > 0f)
            {
                inUse += 1;
                wasinUse = false;
                switchActiveTo(wasinUse);
            }
            lastPos = transform.position;
        }
        else
        {
            inUse -= Time.deltaTime;
            if (inUse > 0f)
            {
                inUse -= 1;
                wasinUse = true;
                switchActiveTo(wasinUse);
            }
        }
        inUse=Mathf.Clamp(inUse, -1, 1);
        
    }
    void switchActiveTo(bool activity)
    {
        foreach(GameObject obj in showOnActive)
        {
            obj.SetActive(activity);
        }
        foreach(GameObject obj in hideOnActive)
        {
            obj.SetActive(!activity);
        }
    }


}
