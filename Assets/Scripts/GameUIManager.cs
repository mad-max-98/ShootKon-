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

    public void ShowEndGameBanner_PauseButton()
    {
        score.text = string.Format("Your Score : {0:00000}", ScoreManager.Instance.Score);
        endGameBanner.SetActive(true);
        continueButton.gameObject.SetActive(true);
    }

    public void HideEndGameBanner ()
    {
        endGameBanner.SetActive (false);
    }

    //Buttons functionality

    public void ContinueCurrentLevelGame ()
    {
        HideEndGameBanner ();
        Time.timeScale = 1.0f;
    }

    public void PauseCurrentLevelGame ()
    {
        Time.timeScale = 0f;

        ShowEndGameBanner_PauseButton();
    }


    public void RestartCurrentScene ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name );
    }

    public void LevelsSceneLoad () 
    {
        SceneManager.LoadScene("Levels");
    }

    public void HomeSceneLoad () 
    {
        SceneManager.LoadScene("Home");
    }

}
