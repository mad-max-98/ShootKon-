using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] float timeInterval;
    [SerializeField] int randomnessFactor;
    //public List<GameObject> EnemyModels = new List<GameObject>();


    //My pools
    private ObjectPool<EnemyController> redEnemyPool;
    private ObjectPool<EnemyController> blueEnemyPool;
    private Transform tr;
    // Start is called before the first frame update
    void Start()
    {
      
        
        
    }

    private void OnEnable()
    {
        //subscribe to losing delegate
        GameStateManager.onLoseGameState += StopSpawnning;

        tr = GetComponent<Transform>();
        //if ( Input.GetKey(KeyCode.N))
        //{
        Debug.Log("Enemy spawner start!");
        StartCoroutine(spawnEnemy(timeInterval, randomnessFactor));
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator spawnEnemy (float interval , int randomness)
    {
        //Debug.Log("New Enemy!" + EnemyModels.Count);
        yield return new WaitForSeconds(interval);
        //Choose between 2 enemies
        int randomNumber = Random.Range(0, 100) > randomness ? 1:0 ;
        Debug.Log("Random number : " + randomNumber);

        //GameObject newEnemy = Instantiate( EnemyModels[randomNumber] ,
        //    new Vector3 (tr.position.x , tr.position.y , tr.position.z) ,
        //    Quaternion.identity);

        if (randomNumber == 1)
        {
            EnemyController redEnemy =  redEnemyPool.Get();
            redEnemy.transform.position = tr.position;
            redEnemy.transform.rotation = Quaternion.identity;
        }
        else
        {
            EnemyController blueEnemy = blueEnemyPool.Get();
            blueEnemy.transform.position = tr.position;
            blueEnemy.transform.rotation = Quaternion.identity;

        }

        StartCoroutine(spawnEnemy(interval , randomness));


    }

    private void OnDisable()
    {
        //unsubscribe to losing delegate
        GameStateManager.onLoseGameState -= StopSpawnning;
    }

    void StopSpawnning ()
    {
        StopAllCoroutines();
    }


    //pool
    public void SetRedPool(ObjectPool<EnemyController> pool)
    {
        redEnemyPool = pool;
    }

    public void SetBluePool(ObjectPool<EnemyController> pool)
    {
        blueEnemyPool = pool;
    }

    public ObjectPool<EnemyController> GetRedPool()
    {
        return redEnemyPool;
    }

    public ObjectPool<EnemyController> GetBluePool()
    {
        return blueEnemyPool;
    }


}
