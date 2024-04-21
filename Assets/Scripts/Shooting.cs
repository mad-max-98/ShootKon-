using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Shooting : MonoBehaviour
{

    public Camera mainCam;
    Vector3 mousePos;
    Vector3 rotation;
    float rotationZ;

    public BulletController BlueBullet;
    public BulletController RedBullet;
    public Transform bulletTransform;
    bool canFire = true;
    public float shootingIntervalTime;
    float timer = 0;

    //RedBullet pool
    private ObjectPool<BulletController> redBulletPool;

    //BlueBullet pool
    private ObjectPool<BulletController> blueBulletPool;


    private void Awake()
    {
        redBulletPool = new ObjectPool<BulletController>(CreateRedBullet, OnGetBulletFromPool, OnTakeBackBulletToPool, OnDestroyExtraBullet, true, 0, 100);

        blueBulletPool = new ObjectPool<BulletController>(CreateBlueBullet, OnGetBulletFromPool, OnTakeBackBulletToPool, OnDestroyExtraBullet, true, 0, 100);
    }
    private void OnEnable()
    {
        //subscribe to losing delegate
        GameStateManager.onLoseGameState += StopPlaying;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, mainCam.nearClipPlane));
        //Debug.Log("Mouse : " + mousePos);
        rotation = mousePos - transform.position;
        rotationZ = Mathf.Atan2 (rotation.y , rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler (0,0,rotationZ);

        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer >= shootingIntervalTime)
            {
                canFire = true;
                timer = 0;
            }
        }

        if (Input.GetMouseButton(0) && canFire)
        {
            canFire = false;
            //Instantiate (BlueBullet, bulletTransform.position, Quaternion.identity);
            blueBulletPool.Get();
        }
        else if (Input.GetMouseButton(1) && canFire)
        {
            canFire = false;
            //Instantiate (RedBullet, bulletTransform.position, Quaternion.identity);
            redBulletPool.Get();
        }
    }


    private void OnDisable()
    {
        //unsubscribe to losing delegate
        GameStateManager.onLoseGameState -= StopPlaying;
    }

    void StopPlaying ()
    {
        this.gameObject.SetActive (false);
    }


    //bullet pool functions

    private BulletController CreateBlueBullet ()
    {
        BulletController blueBullet = Instantiate(BlueBullet, bulletTransform.position, Quaternion.identity);
        //BulletController blueBullet = Instantiate(BlueBullet);
        //blueBullet.transform.position = bulletTransform.position;
        //blueBullet.transform.rotation = Quaternion .identity;
        blueBullet.SetPool(blueBulletPool);
        Debug.LogWarning("Create blue bullet from pool");
        return blueBullet;
    }

    private BulletController CreateRedBullet()
    {
        BulletController redBullet = Instantiate(RedBullet, bulletTransform.position, Quaternion.identity);
        redBullet.SetPool(redBulletPool);
        Debug.LogWarning("Create red bullet from pool");
        return redBullet;

    }

    private void OnGetBulletFromPool (BulletController bullet)
    {
        bullet.gameObject.SetActive (true);
        Debug.LogWarning("get bullet from pool : " + bullet.GetPool().GetType());
    }

    private void OnTakeBackBulletToPool (BulletController bullet)
    {
        bullet.gameObject.SetActive(false);
        Debug.LogWarning("take back bullet to pool : " + bullet.GetPool().GetType());
    }

    private void OnDestroyExtraBullet (BulletController bullet)
    {
        Debug.LogWarning("R.I.P bullet from pool : " + bullet.GetPool().GetType());
        Destroy(bullet.gameObject);
    }

}
