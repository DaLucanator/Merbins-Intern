using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LoadLevelTest : MonoBehaviour
{
    private GlobalLevelLoader levelLoader;

    public void Start()
    {
        //Finds the prefab you have put in your scene
        levelLoader = GameObject.FindGameObjectWithTag("LevelLoader").GetComponent<GlobalLevelLoader>();
    }

    //put this on an object you want to interact with
    //object just needs a collider on it (not trigger)
    //then when you touch the object with the 'finger' it will trigger
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Touch"))
        {
            levelLoader.LoadLevel("Hub");
        }
    }
}
