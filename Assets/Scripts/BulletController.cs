using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    Camera mainCam;
    Vector3 mousePos;
    Rigidbody2D rb;
    public float force;
    public GameObject myEnemy;
    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(new Vector3 (Input.mousePosition.x, Input.mousePosition.y, mainCam.nearClipPlane));
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
        rb.velocity = new Vector2 (direction.x, direction.y).normalized * force;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Detected by bullet");
        if (collision.gameObject.tag == myEnemy.tag)
        {
            
            Destroy(this.gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

}
