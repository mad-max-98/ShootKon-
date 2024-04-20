using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    //Enemy list to detect
    public List<GameObject> Enemies = new List<GameObject>();

    bool triggered = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        UnityEngine.Debug.Log("Enemy in dangerzone!");
        if (collision.gameObject.layer == this.gameObject.layer && triggered == false)
        {
            //foreach (GameObject enemy in Enemies)
            //{
            //    if (enemy.tag == collision.gameObject.tag)
            //    {
                    
                    try
                    {
                        GameStateManager.onLoseGameState();
                    }
                    catch
                    {
                        UnityEngine.Debug.Log("Error : LoseGameState is not defined!");
                    }
                    triggered = true;
                    //break;
            //    }

            //}
        }
        
        
       
    }
}
