using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcessLevel : MonoBehaviour
{
    public string levelName;
    public PassLevel teleport;

    /*public void SentMessageToTeleport()
    {
        if (levelName != null) { teleport.sceneName = levelName; }
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Touch"))
        {
            if (levelName != null)
            {
                teleport.sceneName = levelName;
            }
        }
    }
}
