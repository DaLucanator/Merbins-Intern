using System.Collections;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemName;
    [HideInInspector] public GameObject objectModel;
    [HideInInspector] public Material material;
    public GameObject resultItem;

    public void Awake()
    {
        if (itemName == null) { gameObject.name = itemName; }
        objectModel = this.transform.GetChild(0).gameObject;
        material = this.transform.GetChild(0).GetComponent<Renderer>().material;
    }
}
