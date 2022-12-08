using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class KeyPadControl : MonoBehaviour
{
    //intergers to hold the number for randomness and the combination for the lock
    public int randNumber;
    public int correctCombination;
    public bool accessGranted = false;

    //objects for success after getting the combination
    public GameObject glass;
    public GameObject crystal;

    public AudioSource audioPlaying;

    //object and material for posters to randomise from
    public GameObject poster;
    public Material mat1;
    public Material mat2;
    public Material mat3;
    public Material mat4;

    private void Awake()
    {
        //very first thing create a random number to decide poster
        randNumber = Random.Range(1, 4);
        
    }

    // Start is called before the first frame update
    void Start()
    {
        //turns off the grab interactable on the crystal so the player can't grab it through the glass
        crystal.GetComponent<XRGrabInteractable>().enabled = false;

        //checks what the random number is and chooses the correct material and combination to go with it
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
        //checks if the bool has been changed to true
        if (accessGranted == true)
        {

            glass.GetComponent<Animator>().Play("OpenGlass");
            
            crystal.GetComponent<XRGrabInteractable>().enabled = true;
            accessGranted = false;
        }
    }

    public bool CheckIfCorrect(int combination)
    {
        //checks the 2 combinations
        if (combination == correctCombination)
        {
            //plays a sound
            audioPlaying.Play();
            //sets the bool
            accessGranted = true;
            return true;
        }
        return false;
    }
}
