using UnityEngine;
using System.Collections.Generic;


public class Printer : MonoBehaviour
{
    [SerializeField] GameObject item;

    [SerializeField] GameObject itemSlotItem;
    [SerializeField] GameObject itemSlotProceed;

    [HideInInspector] [SerializeField] int currentCount;
    [SerializeField] int limitCount;
    [HideInInspector] [SerializeField] List<GameObject> catalogPrintedItems;

    //declaing the location where the prefab will appear.
    [Tooltip("Spawn point for Item")]
    public Transform SpawnPointItem;
    [Tooltip("Spawn point to Cancel")]
    public Transform SpawnPointCancel;
    [Tooltip("Spawn point to Proceed")]
    public Transform SpawnPointProceed;

    public AudioSource printSound;

    private void Update()
    {
        currentCount = catalogPrintedItems.Count;


        for (int i = 0; i < catalogPrintedItems.Count; i++)
        {
            if (catalogPrintedItems[i] == null)
            {
                catalogPrintedItems.RemoveAt(i);
            }
        }
    }

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
                    itemSlotItem.transform.localScale = other.gameObject.transform.localScale;
                }
            }
        }
    }
    public void ProceedCraftItem()
    {
        if (printSound != null)
        {
            printSound.Play();
        }

        if (itemSlotItem != null)
        {
            if (currentCount < limitCount + 1)
            {
                itemSlotProceed = Instantiate(item.GetComponent<Item>().resultItem, SpawnPointProceed.transform.position, SpawnPointProceed.transform.rotation);
                itemSlotProceed.gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().material = item.GetComponent<Item>().material;
                itemSlotProceed.name = item.GetComponent<Item>().resultItem.name.Replace("(Clone)", "").Trim();
                // itemSlotProceed.transform.localScale = item.transform.localScale;

                catalogPrintedItems.Add(itemSlotProceed);

                itemSlotProceed = null;
            }

            if (currentCount == limitCount)
            {
                Destroy(catalogPrintedItems[0]);
                catalogPrintedItems.Remove(catalogPrintedItems[0]);
            }
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
