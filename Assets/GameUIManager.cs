using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{

    public GameObject endGameBanner;
    public Button continueButton;
    public TextMeshProUGUI score;

    private void OnEnable()
    {
        GameStateManager.onLoseGameState += ShowEndGameBanner;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnDisable()
    {
        GameStateManager.onLoseGameState -= ShowEndGameBanner;
    }




    public void ShowEndGameBanner () 
    {
        score.text = string.Format("Your Score : {0:00000}", ScoreManager.Instance.Score);
        endGameBanner.SetActive (true);
        continueButton.gameObject.SetActive (false);
    }

    public void ShowEndGameBanner_StopButton()
    {
        endGameBanner.SetActive(true);
        continueButton.gameObject.SetActive(true);
    }

    public void HideEndGameBanner ()
    {
        endGameBanner.SetActive (false);
    }

    //Buttons functionality

    public static void ContinueCurrentLevelGame ()
    {

    }


    public static void RestartCurrentScene ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name );
    }

    public static void LevelsSceneLoad () { }

    public static void HomeSceneLoad () 
    {
        SceneManager.LoadScene("Home");
    }

}
