using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class KeyPadControl : MonoBehaviour
{
    public int randNumber;
    public int correctCombination;
    public bool accessGranted = false;

    public GameObject glass;
    public GameObject crystal;

    public GameObject poster;
    public Material mat1;
    public Material mat2;
    public Material mat3;
    public Material mat4;

    private void Awake()
    {
        randNumber = Random.Range(1, 4);
        
    }

    // Start is called before the first frame update
    void Start()
    {
        glass.SetActive(true);
        crystal.GetComponent<XRGrabInteractable>().enabled = false;

        if (randNumber == 1)
        {
            poster.GetComponent<Renderer>().material = mat1;
            correctCombination = 1511;
        }
        if (randNumber == 2)
        {
            poster.GetComponent<Renderer>().material = mat2;
            correctCombination = 1797;
        }
        if (randNumber == 3)
        {
            poster.GetComponent<Renderer>().material = mat3;
            correctCombination = 2495;
        }
        if (randNumber == 4)
        {
            poster.GetComponent<Renderer>().material = mat4;
            correctCombination = 2712;
        }
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
