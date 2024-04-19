using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] float timeInterval;
    [SerializeField] int randomnessFactor;
    public List<GameObject> EnemyModels = new List<GameObject>();
    Transform tr;
    // Start is called before the first frame update
    void Start()
    {
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
        Debug.Log("New Enemy!" + EnemyModels.Count);
        yield return new WaitForSeconds(interval);
        //Choose between 2 enemies
        int randomNumber = Random.Range(0, 100) > randomness ? 1:0 ;
        Debug.Log("Random number : " + randomNumber);
        GameObject newEnemy = Instantiate( EnemyModels[randomNumber] ,
            new Vector3 (tr.position.x , tr.position.y , tr.position.z) ,
            Quaternion.identity);

        StartCoroutine(spawnEnemy(interval , randomness));


    }
}
