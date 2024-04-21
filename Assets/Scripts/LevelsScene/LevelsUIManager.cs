using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelsUIManager : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI level1Highscore;
    [SerializeField] private TextMeshProUGUI level2Highscore;

    private void Start()
    {
        try
        {
            Debug.Log("Start levels highscore");
            level1Highscore.text = string.Format("Highscore : {0:00000}", PlayerPrefs.GetFloat("Level1Highscore"));
            level2Highscore.text = string.Format("Highscore : {0:00000}", PlayerPrefs.GetFloat("Level2Highscore"));
        } catch { };
        
    }

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
        //SceneManager.LoadSceneAsync("Level2");
    }


}
