using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string sceneName;

    public void DoLoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadSceneByName(string _sceneName)
    {
        SceneManager.LoadScene(_sceneName);
    }
}