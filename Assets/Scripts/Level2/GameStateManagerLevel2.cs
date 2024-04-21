using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManagerLevel2 : MonoBehaviour
{
    //Singleton
    //public static GameStateManager Instance {  get; private set; }

    //private void Awake()
    //{
    //    Instance = this;
    //}

    public delegate void LoseState();
    public static LoseState onLoseGameState;


    // Start is called before the first frame update
    void Start()
    {
        //Avoiding to be null
        onLoseGameState += UpdateLevel2Highscore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateLevel2Highscore ()
    {

        //If this is the first time that level1 is being played or this time player's score is more than last highest score, update level1's highscore

        if (PlayerPrefs.HasKey("Level2Highscore") == false || PlayerPrefs.GetFloat("Level2Highscore") < ScoreManager.Instance.Score)
            PlayerPrefs.SetFloat("Level2Highscore", ScoreManager.Instance.Score);



        //if (PlayerPrefs.HasKey("Level1Highscore") == true)
        //{
        //    if (PlayerPrefs.GetFloat("Level1Highscore") < ScoreManager.Instance.Score)
        //    {
                
        //    }

        //} else { PlayerPrefs.SetFloat("Level1Highscore", ScoreManager.Instance.Score); }

        PlayerPrefs.Save();
            
    }
}
