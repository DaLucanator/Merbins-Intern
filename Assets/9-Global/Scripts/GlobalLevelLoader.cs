using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalLevelLoader : MonoBehaviour
{
    [SerializeField] private string levelToLoad;
    [SerializeField] private float timeToWait;
    [SerializeField] private bool testLevelLoader;
    [SerializeField] private GameObject portalObject;

    public void Start()
    {
        if (testLevelLoader) { StartCoroutine(LoadLevelTimer()); }
    }

    public void LoadLevel()
    {
        StartCoroutine(LoadLevelTimer());
    }

    IEnumerator LoadLevelTimer()
    {
        PortalEffect();

        yield return new WaitForSeconds(timeToWait);

        if (levelToLoad != null) { SceneManager.LoadScene(levelToLoad); }
        Debug.Log("Please enter level name to Level Loader. Thankyou :)");
    }

    void PortalEffect()
    {
        Instantiate(portalObject);
    }
}
