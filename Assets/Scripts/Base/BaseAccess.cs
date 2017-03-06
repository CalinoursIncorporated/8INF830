using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BaseAccess : MonoBehaviour {

    public Text ButtonPrompt;

	// Use this for initialization
	void Start () {
        ButtonPrompt.enabled = false;
	}

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        ButtonPrompt.enabled = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown("e"))
        {
            SceneManager.LoadSceneAsync("Bridge", LoadSceneMode.Single);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        ButtonPrompt.enabled = false;
    }
}
