using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BaseAccess : MonoBehaviour
{
    public string sceneToAccessName;
    public Text buttonPrompt;
    public GameObject baseAudio;

    private void OnTriggerEnter(Collider other)
    {
        buttonPrompt.gameObject.SetActive(true);
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetAxis("Submit") > 0)
        {
            Cursor.visible = true;
            Instantiate(baseAudio);
            GameObject.Find("Data").GetComponentInChildren<QuestProgress>().StopTimer();
            SceneManager.LoadScene(sceneToAccessName, LoadSceneMode.Single);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        buttonPrompt.gameObject.SetActive(false);
    }
}
