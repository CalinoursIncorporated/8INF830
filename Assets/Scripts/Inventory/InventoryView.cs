using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventoryView : MonoBehaviour {

	public GameObject inventoryPanel;
	public GameObject slotPanel;
	public GameObject inventorySlot;
	public GameObject inventoryItem;

	/// <summary>
	/// The slot amount.
	/// </summary>
	private int slotAmount;

	private InventoryModel inventoryModel;

	/// <summary>
	/// List of slots.
	/// </summary>
	public GameObject[] slots;

	/// <summary>
	/// which slots countains which item ? this allows the link between the models item and the view item.
	/// </summary>
	public Dictionary<Item, int> itemsData = new Dictionary<Item, int>(); 

	/// <summary>
	/// instantiate item and slot list.
	/// </summary>
	void Start(){
		inventoryModel = this.gameObject.GetComponent<InventoryModel> ();
		slotAmount = inventoryModel.slotsAmount; 
		slots = new GameObject[slotAmount];

		for (int i = 0; i < slotAmount; i++) {
			slots [i] = Instantiate (inventorySlot);
			slots [i].transform.SetParent (slotPanel.transform);
		}

	}
		

	public void updateAddNewItemView(Item itemToAdd, int amount = 1){

		int emptySlotPointer = -1;
		for (int i = 0; i < slotAmount; i++) { // Finding an empty slot
			if (slots [i].transform.childCount == 0) { // Empty slot
				emptySlotPointer = i;
				break;
			}
		}

		GameObject itemObj = Instantiate (inventoryItem, slots [emptySlotPointer].transform); // creates the itemView
		itemObj.GetComponent<Image> ().sprite = itemToAdd.Sprite; // sets the sprite
		itemObj.GetComponent<ItemData>().item = itemToAdd; // sets the item	
		itemObj.transform.localPosition = Vector2.zero; // sets the position of the item according to the slot
		itemObj.name = itemToAdd.Title; // sets the name of the gameObject
		itemObj.transform.GetChild (0).GetComponent<Text> ().text = amount.ToString (); // sets the amount text

		itemsData.Add (itemToAdd, emptySlotPointer); // Ads the itemData
	}

	public void updateAmountItemView(Item itemToUpdate, int amount = 1){
		int slot = itemsData [itemToUpdate]; // Gets the item slot position
		slots[slot].transform.GetChild (0).GetChild(0).GetComponent<Text> ().text = amount.ToString (); // updates the amount text
	}


	public void updateRemoveItemView(Item itemToRemove){
		int slot = itemsData [itemToRemove]; // Gets the item slot position
		Destroy (slots [slot].transform.GetChild (0).gameObject); // Destroy the item gameObject

		itemsData.Remove(itemToRemove); // Removes the itemData
	}

	public void updateMoveItemView(Item itemToMove, GameObject slotToFill){
		int slotToTakePos = itemsData [itemToMove]; // Gets the item slot position
		int slotToFillPos = -1;

		for (int i = 0; i < slotAmount; i++) { // Look for slotToFillPosition
				if (slots[i].GetInstanceID() == slotToFill.GetInstanceID()){
				slotToFillPos = i;
				break;
				}
		}
			
		if (slotToFill.transform.childCount == 0) { // Empty Slot
			slots [slotToTakePos].transform.GetChild (0).SetParent (slotToFill.transform); // Sets the parent of current itemToMove
			itemsData [itemToMove] = slotToFillPos; // Adds a new itemsData
		} else { // NotEmptySlot
			Item itemToReplace = null;
			foreach (Item key in itemsData.Keys)
			{
				if (itemsData [key] == slotToFillPos) {
					itemToReplace = key;
					break;
				}
			}

			slots [slotToTakePos].transform.GetChild (0).SetParent (slotToFill.transform); // Sets the parent of current itemToMove
			slotToFill.transform.GetChild(0).position = slots[slotToTakePos].transform.position; // Sets the position of current itemToReplace
			slotToFill.transform.GetChild (0).SetParent(slots[slotToTakePos].transform); // Sets the parent of current itemToReplace

			itemsData [itemToMove] = slotToFillPos; // Updates informations about itemtomove slot
			itemsData [itemToReplace] = slotToTakePos; // Updates informations about itemtoreplace slot
		}

	}

}


	