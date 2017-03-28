using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Trash : MonoBehaviour, IDropHandler
{

    private InventoryController inventoryController;
    private InventoryModel inventoryModel;

    void Start()
    {
        GameObject tem = GameObject.Find("Inventory");
        if(tem == null)
        {
            gameObject.SetActive(false);
        }
        else
        {
            inventoryController = GameObject.Find("Inventory").GetComponent<InventoryController>();
            inventoryModel = GameObject.Find("Inventory").GetComponent<InventoryModel>();
        }

        
    }

    /// <summary>
    /// Event called when an element is dropped in the trash.
    /// </summary>
    /// <param name="eventData">Mouse Pointer eventData</param>
    public void OnDrop(PointerEventData eventData)
    {
        ItemData droppedItem = eventData.pointerDrag.GetComponent<ItemData>();
        inventoryController.RemoveItem(droppedItem);
    }


}
