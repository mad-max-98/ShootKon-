using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EnemyController : MonoBehaviour
{
    private Vector3 playerPos;
    private Rigidbody2D rb;
    [SerializeField] float force;

    //My pool
    private ObjectPool<EnemyController> _pool;


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

    ////pool
    public void SetPool(ObjectPool<EnemyController> pool)
    {
        _pool = pool;
    }

    public ObjectPool<EnemyController> GetPool()
    {
        return _pool;
    }

    void StopMoving ()
    {
        rb.velocity = Vector3.zero;
    }
}
