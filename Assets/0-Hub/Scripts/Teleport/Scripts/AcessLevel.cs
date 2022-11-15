using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcessLevel : MonoBehaviour
{
    public string levelName;
    public PassLevel teleport;

    public void SentMessageToTeleport()
    {
        if (levelName != null) { teleport.sceneName = levelName; }
    }
}
