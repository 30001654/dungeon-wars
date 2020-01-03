using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    //Loads different scenes based on the index given
    public void SceneLoader(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
