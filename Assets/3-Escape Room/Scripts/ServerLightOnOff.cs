using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerLightOnOff : MonoBehaviour
{
    public bool isFlickering = false;
    public bool serverFixed = false;
    public float timeDelay = 0.1f;
    public GameObject serverShelf;

    private void Start()
    {
        this.gameObject.GetComponent<Light>().color = Color.red;
    }

    public void lightCheck()
    {
        serverFixed = true;
    }

    private void Update()
    {
        if (isFlickering == false & serverFixed == false)
        {
            StartCoroutine(FlickeringLight());
        }
        if (serverFixed == true)
        {
            StopCoroutine(FlickeringLight());
            this.gameObject.GetComponent<Light>().enabled = true;
            this.gameObject.GetComponent<Light>().color = Color.green;
            serverShelf.GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
        }
    }

    IEnumerator FlickeringLight()
    {
        isFlickering = true;
        this.gameObject.GetComponent<Light>().enabled = false;
        //timeDelay = Random.Range(0.01f, 0.2f);
        yield return new WaitForSeconds(timeDelay);
        this.gameObject.GetComponent<Light>().enabled = true;
        yield return new WaitForSeconds(timeDelay);
        isFlickering = false;
    }
}
