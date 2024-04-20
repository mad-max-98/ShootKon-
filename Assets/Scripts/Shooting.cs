using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public Camera mainCam;
    Vector3 mousePos;
    Vector3 rotation;
    float rotationZ;

    public GameObject BlueBullet;
    public GameObject RedBullet;
    public Transform bulletTransform;
    bool canFire = true;
    public float shootingIntervalTime;
    float timer = 0;

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
            Instantiate (BlueBullet, bulletTransform.position, Quaternion.identity);
        }
        else if (Input.GetMouseButton(1) && canFire)
        {
            canFire = false;
            Instantiate (RedBullet, bulletTransform.position, Quaternion.identity);
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
}
