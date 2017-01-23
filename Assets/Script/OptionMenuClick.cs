using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionMenuClick : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.SetActive(false);
	}

    public void OnSave()
    {
        //TODO
    }

    public void OnReturnMainMenu()
    {
        //TODO
    }

    public void OnLaunchMenu()
    {
        gameObject.SetActive(true);
        //TODO : Pause game, unlock cursor
    }

    public void OnResumeGame()
    {
        gameObject.SetActive(false);
        //TODO : UnpauseGame, lock cursor
    }

    public void OnQuitGame()
    {
        Application.Quit();
    }
}
