using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Vector3 playerPos;
    Rigidbody2D rb;
    [SerializeField] float force;

    private void OnEnable()
    {
        //subscribe to losing delegate
        GameStateManager.onLoseGameState += StopMoving;
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        Vector3 direction = playerPos - transform.position;
        rb.velocity = new Vector2 (direction.x, direction.y).normalized * force;
        float rotation = Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler (0,0,rotation);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDisable()
    {
        //unsubscribe to losing delegate
        GameStateManager.onLoseGameState -= StopMoving;
    }

    void StopMoving ()
    {
        rb.velocity = Vector3.zero;
    }
}
