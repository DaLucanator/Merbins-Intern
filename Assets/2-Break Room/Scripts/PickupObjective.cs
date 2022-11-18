using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObjective : MonoBehaviour
{
    [SerializeField] Vector3 lastPos;
    [SerializeField] float inUse;
    



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
        switchActiveTo(false);
    }



    private void FixedUpdate()
    {
        if (lastPos != transform.position)
        {
            inUse += Time.deltaTime;
            if (inUse > 0f)
            {
                inUse += 1;
                switchActiveTo(true);
            }
            lastPos = transform.position;
        }
        else
        {
            inUse -= Time.deltaTime;
            if (inUse < 0f)
            {
                inUse -= 1;
                switchActiveTo(false);
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
        GameObject.FindGameObjectWithTag("CleaningManager").GetComponent<L2_CleaningManager>().otherActivityChange(gameObject,activity);
    }


}
