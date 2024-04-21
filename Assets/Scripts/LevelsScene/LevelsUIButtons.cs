using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsUIButtons : MonoBehaviour
{

    public void BackButtonUI ()
    {
        SceneManager.LoadSceneAsync("Home");
    }

    public void Level1ButtonUI ()
    {
        SceneManager.LoadSceneAsync("Level1");
    }

    public void Level2ButtonUI()
    {
        SceneManager.LoadSceneAsync("Level2");
    }


}
