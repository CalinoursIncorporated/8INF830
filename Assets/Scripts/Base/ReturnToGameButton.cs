using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToGameButton : MonoBehaviour
{
    public void Click(string sceneToLoad)
    {
        if(GameObject.Find("BaseAudio"))
        {
            Destroy(GameObject.Find("BaseAudio"));
        }
        if (GameObject.Find("BaseAudio(Clone)"))
        {
            Destroy(GameObject.Find("BaseAudio(Clone)"));
        }
        SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Single);
    }
}
