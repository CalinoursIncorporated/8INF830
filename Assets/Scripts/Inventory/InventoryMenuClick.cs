using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMenuClick : MonoBehaviour {

	// Use this for initialization
	void Start()
	{
		gameObject.SetActive(false);
	}
		


	/// <summary>
	/// Use when the user open the in game inventory. 
	/// </summary>
	public void OnLaunch()
	{
		if (gameObject.activeInHierarchy) {

			OnResume ();
		} else {

			gameObject.SetActive (true);
		}
		//TODO : unlock cursor
	}

	/// <summary>
	/// Use when the user click on the resume menu button
	/// close the menu
	/// </summary>
	public void OnResume()
	{
		gameObject.SetActive(false);
		//TODO : lock cursor
	}
	/// <summary>
	/// Use when the user clik on the Quit menu button
	/// </summary>
	public void OnQuitGame()
	{
		Application.Quit();
	}
}
