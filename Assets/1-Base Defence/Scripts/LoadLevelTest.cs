using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevelTest : MonoBehaviour
{
    [SerializeField] private GlobalLevelLoader levelLoader;

    public void Start()
    {
        levelLoader.LoadLevel();
    }
}
