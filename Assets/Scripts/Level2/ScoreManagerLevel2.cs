using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;



public class ScoreManagerLevel2 : MonoBehaviour
{
    //Constants
    private const float EnemyKillingScore = 1f;

    //Singleton
    public static ScoreManagerLevel2 Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }

    public TextMeshProUGUI scoreUIText;

    //Player's Score in current play
    public float Score { get; private set; }

    public void IncreaseScoreByKillingEnemy ()
    {
        Score += EnemyKillingScore ;
        UpdateScoreUI();
    }

    public void UpdateScoreUI ()
    {
        scoreUIText.text = string.Format("Score: {0:00000}", Score);
    }
    // Start is called before the first frame update
    void Start()
    {
        //Initialize score
        Score = 0 ;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            try { Debug.Log("Level 2 Highscore : " + PlayerPrefs.GetFloat("Level2Highscore"));  } catch { }
            
        }
    }
}
