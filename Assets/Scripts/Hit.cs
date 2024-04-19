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
        Debug.Log("Detected by enemy");
        //Bullet is destroyed whether it's color is the same as enemy or not!
        Destroy(collision.gameObject);
        //If their colors are the same, then kill the enemy!
        if (collision.gameObject.tag == myKillerBullet.tag)
        {
            
            Destroy(this.gameObject);

        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }



}
