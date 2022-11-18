using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalLevelLoader : MonoBehaviour
{
    [SerializeField] private float timeToWait;
    [SerializeField] private GameObject portalObject;

    public void LoadLevel(string levelToLoad)
    {
        StartCoroutine(LoadLevelTimer(levelToLoad));
    }

    IEnumerator LoadLevelTimer(string levelToLoad)
    {
        //PortalEffect();

        yield return new WaitForSeconds(timeToWait);

        SceneManager.LoadScene(levelToLoad);
    }

    void PortalEffect()
    {
        Instantiate(portalObject);
    }
}
