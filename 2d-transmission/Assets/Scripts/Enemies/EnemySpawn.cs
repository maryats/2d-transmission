using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public float spawnTime = 3f;
    public float intSpawn = 1f;
    // Use this for initialization
    void Start()
    {
        Invoke("SpawnEnemy", intSpawn);
        InvokeRepeating("DeathCheck", spawnTime, spawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnEnemy()
    {
        if (!gameObject.activeSelf)
        {
            gameObject.SetActive(true);
            Debug.Log("Spawned");
        }
        
    }

    void DeathCheck()
    {
        if (gameObject.activeSelf == false)
        {
            Invoke("SpawnEnemy", spawnTime);
            Debug.Log("Spawning in 3");
        }
    }

    IEnumerator  Spawn()
    {
        yield return new WaitForSeconds(intSpawn);

        SpawnEnemy();
    }
}






