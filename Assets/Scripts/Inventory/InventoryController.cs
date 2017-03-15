using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour {

	public TextAsset itemJSON;

	/// <summary>
	/// The database.
	/// </summary>
	private ItemDatabase database;

	private InventoryModel inventoryModel;
	private InventoryView inventoryView;


	void Start(){
		database = ItemDatabase.Instance (itemJSON);
		inventoryModel = this.gameObject.GetComponent<InventoryModel> ();
		inventoryView = this.gameObject.GetComponent<InventoryView> ();
		addItem (0,5);
		addItem (1,5);

	}


		
	/// <summary>
	/// Adds the item and its amount to the dictionnary.
	/// </summary>
	/// <param name="itemToAdd">Item to add.</param>
	/// <param name="amount">Amount.</param>
	public void addItem(int itemID, int amount = 1){
		Item itemToAdd = database.FetchItemByID (itemID);

		int slotsAmount = inventoryModel.slotsAmount;
		Dictionary<Item,int> inventory = inventoryModel.inventory;

		if (itemToAdd.Stackable && inventory.ContainsKey(itemToAdd)) { // if the item is already in the list and is stackable
				inventory[itemToAdd] += amount; // updates the amount of the model
				inventoryView.updateAmountItemView(itemToAdd,inventory[itemToAdd]); // updates the view
			}
		 else { // if the item is not in the list
			if (inventory.Count < slotsAmount) { // if there is an empty spot
					inventory.Add (itemToAdd, amount); // adds the item and its amount of the model
					inventoryView.updateAddNewItemView(itemToAdd,amount); // updates the view
				}
		 }

	}


	/// <summary>
	/// Removes the item (or at least reduce its amount).
	/// </summary>
	/// <param name="itemToRemove">Item to remove.</param>
	/// <param name="amount">Amount.</param>
	public void removeItem(int itemID, int amount = 1){
		Item itemToRemove = database.FetchItemByID (itemID);

		Dictionary<Item,int> inventory = inventoryModel.inventory;

		if (inventory.ContainsKey(itemToRemove)) { // if the item is in the list
			if (amount < inventory[itemToRemove]){ // if the amount to remove is lower than the amount in the inventory
				inventory[itemToRemove] -= amount; // updates the amount of the model
				inventoryView.updateAmountItemView(itemToRemove, inventory[itemToRemove]); // updates the view
			}
			else{ // remove the item completely
				inventory.Remove(itemToRemove); // remove the item
				inventoryView.updateRemoveItemView(itemToRemove); // updates the view
			}
		}
	}

}
