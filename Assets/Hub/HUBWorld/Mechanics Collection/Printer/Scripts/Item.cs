using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemName;
    public GameObject objectModel;
    public Material material;
    public GameObject resultItem;

    public void Awake()
    {
        gameObject.name = itemName;
    }
}
