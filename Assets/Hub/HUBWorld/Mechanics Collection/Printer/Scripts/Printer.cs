using UnityEngine;
using System.Collections.Generic;


public class Printer : MonoBehaviour
{
    [SerializeField] GameObject item;

    GameObject itemSlotItem;
    GameObject itemSlotProceed;

    //declaing the location where the prefab will appear.
    [Tooltip("Spawn point for Item")]
    public Transform SpawnPointItem;
    [Tooltip("Spawn point to Cancel")]
    public Transform SpawnPointCancel;
    [Tooltip("Spawn point to Proceed")]
    public Transform SpawnPointProceed;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Item>())
        {
            if (itemSlotItem == null)
            {
                item = other.gameObject;
                item.SetActive(false);
                if (item != null)
                {
                    //itemSlotB = itemA.gameObject.GetComponent<Item>().model;
                    itemSlotItem = Instantiate(other.gameObject.GetComponent<Item>().objectModel, SpawnPointItem.transform.position, SpawnPointItem.transform.rotation);
                    itemSlotItem.name = itemSlotItem.name.Replace("(Clone)", "").Trim();
                }
            }
        }
    }
    public void ProceedCraftItem()
    {
        if (itemSlotItem != null)
        {
            itemSlotProceed = Instantiate(item.GetComponent<Item>().resultItem, SpawnPointProceed.transform.position, SpawnPointProceed.transform.rotation);
            itemSlotProceed.gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().material = item.GetComponent<Item>().material;
            itemSlotProceed.name = itemSlotItem.name.Replace("(Clone)", "").Trim();
        }
    }

    public void CancelCraftItem()
    {
        if (item != null)
        {
            item.gameObject.transform.position = SpawnPointCancel.transform.position;
            item.gameObject.SetActive(true);
            item = null;
            Destroy(itemSlotItem);
            itemSlotItem = null;

            Destroy(itemSlotProceed);
            itemSlotProceed = null;
        }
    }
}
