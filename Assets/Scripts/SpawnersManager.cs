using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnersManager : MonoBehaviour
{

    [SerializeField] private List <EnemySpawner> EnemySpawners =  new List <EnemySpawner>();
    public float activationInterval;
    public int maximumEnemySpawners;
    private int activeSpawners;
    // Start is called before the first frame update

    private void Awake()
    {
        //De-activate any enemy spawner in the first place
        foreach (EnemySpawner item in EnemySpawners) { item.gameObject.SetActive(false); }
        //Active at least one
        EnemySpawners[0].gameObject.SetActive(true);
        activeSpawners = 0;
    }

    void Start()
    {

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
                    EnemySpawners[i].gameObject.SetActive(true);
                    activeSpawners++;
                    break;
                }
            }
        }

        //Repeat
        StartCoroutine(activateSpawners(activationInterval));
    }
}
