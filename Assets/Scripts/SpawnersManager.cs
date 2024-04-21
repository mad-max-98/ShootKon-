using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class SpawnersManager : MonoBehaviour
{

    [SerializeField] private List <EnemySpawner> EnemySpawners =  new List <EnemySpawner>();
    public float activationInterval;
    public int maximumEnemySpawners;
    private int activeSpawners;

    public EnemyController blueEnemy;
    public EnemyController redEnemy;

    //red enemies pool
    private ObjectPool<EnemyController> redsPool;
    private ObjectPool <EnemyController> bluesPool;

    // Start is called before the first frame update

    private void Awake()
    {
        //De-activate any enemy spawner in the first place
        foreach (EnemySpawner item in EnemySpawners) { item.gameObject.SetActive(false); }
        activeSpawners = 0;

        //initiate pools
        redsPool = new ObjectPool<EnemyController> (CreateRedEnemy, OnGetEnemyFromPool, OnTakeBackEnemyToPool,OnDestroyExtraEnemy,true,0,100);
        bluesPool = new ObjectPool<EnemyController>(CreateBlueEnemy, OnGetEnemyFromPool, OnTakeBackEnemyToPool, OnDestroyExtraEnemy, true, 0, 100);
    }

    private void OnEnable()
    {
        //subscribe to losing delegate
        GameStateManager.onLoseGameState += StopSpawners;
    }

    void Start()
    {
        //Activate at least one
        InitiateAndActiveSpawner(EnemySpawners[0]);

        StartCoroutine(activateSpawners(activationInterval));
        
    }

    // Update is called once per frame
    void Update()
    {
     

    }

    private IEnumerator activateSpawners (float interval)
    {
        yield return new WaitForSeconds(interval);
        if (activeSpawners < maximumEnemySpawners)
        {
            for (int i = 0; i < EnemySpawners.Count; i++)
            {
                if (EnemySpawners[i].gameObject.activeInHierarchy == false)
                {
                    InitiateAndActiveSpawner(EnemySpawners[i]);
                    
                    break;
                }
            }
        }

        //Repeat
        StartCoroutine(activateSpawners(activationInterval));
    }


    private void OnDisable()
    {
        //unsubscribe to losing delegate
        GameStateManager.onLoseGameState -= StopSpawners;
    }

    void StopSpawners ()
    {
        StopAllCoroutines();
        //De-activate any enemy spawner
        foreach (EnemySpawner item in EnemySpawners) { item.gameObject.SetActive(false); }
    }

    void InitiateAndActiveSpawner (EnemySpawner spawner)
    {
        spawner.gameObject.SetActive(true);
        spawner.SetBluePool(bluesPool);
        spawner.SetRedPool(redsPool);
        activeSpawners++;

    }


    //pools' functions

    private EnemyController CreateBlueEnemy()
    {
        EnemyController _blueEnemy = Instantiate(blueEnemy);
        //BulletController blueBullet = Instantiate(BlueBullet);
        //blueBullet.transform.position = bulletTransform.position;
        //blueBullet.transform.rotation = Quaternion .identity;
        _blueEnemy.SetPool(bluesPool);
        Debug.LogWarning("Create blue enemy from pool");
        return _blueEnemy;
    }

    private EnemyController CreateRedEnemy()
    {
        EnemyController _redEnemy = Instantiate(redEnemy);
        //BulletController blueBullet = Instantiate(BlueBullet);
        //blueBullet.transform.position = bulletTransform.position;
        //blueBullet.transform.rotation = Quaternion .identity;
        _redEnemy.SetPool(redsPool);
        Debug.LogWarning("Create blue enemy from pool");
        return _redEnemy;

    }

    private void OnGetEnemyFromPool(EnemyController enemy)
    {
        enemy.gameObject.SetActive(true);
        Debug.LogWarning("get Enemy from pool : " + enemy.GetPool().GetType());
    }

    private void OnTakeBackEnemyToPool(EnemyController enemy)
    {
        enemy.gameObject.SetActive(false);
        Debug.LogWarning("take back Enemy to pool : " + enemy.GetPool().GetType());
    }

    private void OnDestroyExtraEnemy(EnemyController enemy)
    {
        Debug.LogWarning("R.I.P Enemy from pool : " + enemy.GetPool().GetType());
        Destroy(enemy.gameObject);
    }

}
