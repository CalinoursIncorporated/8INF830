using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler {

	private InventoryView inventoryView;


	void Start(){
		inventoryView = GameObject.Find ("Inventory").GetComponent<InventoryView> ();
	}




	/// <summary>
	/// Event called when an element is dropped in a slot.
	/// </summary>
	/// <param name="eventData">Mouse Pointer eventData</param>
	public void OnDrop(PointerEventData eventData){
		if (eventData.pointerDrag.GetComponent<ItemData>().item != null) {
			inventoryView.updateMoveItemView (eventData.pointerDrag.GetComponent<ItemData>().item, this.gameObject);
		}
	}




}
