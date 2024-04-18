using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera mainCam ;
    Vector3 centerOfTheWorld;
    //Vector3 distance;
    void Awake() 
    {
        //Task 1 :: Make sure to have player in center of screen 
        centerOfTheWorld = mainCam.ScreenToWorldPoint(new Vector3 (Screen.width / 2,Screen.height / 2, 0));
        transform.position = new Vector3 (centerOfTheWorld.x,centerOfTheWorld.y,transform.position.z);
        Debug.Log("Player is in the center of the screen!");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // distance = centerOfTheWorld - transform.position;
        // if (distance > 0) {

        // }
    }
}
