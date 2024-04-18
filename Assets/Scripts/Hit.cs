using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    public GameObject myKillerBullet;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        // if(GameObject.ReferenceEquals( collision.gameObject, myKillerBullet.gameObject))
        // {
        //     Debug.Log("Detected");
        //     Destroy(this.gameObject);
        // }
        Debug.Log("Detected by enemy");
        if (collision.gameObject.tag == myKillerBullet.tag)
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);

        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }



}
