using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class KeyPadControl : MonoBehaviour
{
    public int correctCombination;
    public bool accessGranted = false;

    public GameObject glass;
    public GameObject crystal;
    // Start is called before the first frame update
    void Start()
    {
        glass.SetActive(true);
        crystal.GetComponent<XRGrabInteractable>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (accessGranted == true)
        {
            glass.SetActive(false);
            crystal.GetComponent<XRGrabInteractable>().enabled = true;
            accessGranted = false;
        }
    }

    public bool CheckIfCorrect(int combination)
    {
        if (combination == correctCombination)
        {
            accessGranted = true;
            return true;
        }
        return false;
    }
}
