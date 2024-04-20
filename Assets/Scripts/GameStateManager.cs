using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
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
        onLoseGameState += TempFunction;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TempFunction ()
    {
        ;
    }
}
