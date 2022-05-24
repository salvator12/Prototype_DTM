using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalancingSpawn : MonoBehaviour
{
    public GameObject[] spawnGoblin;
    public GameObject[] spawnMiniBoss;
    public GameObject[] spawnBoss;

    // Start is called before the first frame update
    
    // Update is called once per frame
    void Update()
    {
        if (SpawnEnemy.waves == 1)
        {

            spawnGoblin[0].SetActive(true);
        }else if (SpawnEnemy.waves == 2)
        {
            spawnMiniBoss[0].SetActive(true);

        }else if (SpawnEnemy.waves == 3)
        {
            spawnGoblin[0].SetActive(false);
            spawnMiniBoss[0].SetActive(false);
            spawnGoblin[1].SetActive(true);

        }else if (SpawnEnemy.waves == 4)
        {
            spawnMiniBoss[1].SetActive(true);

        }else if (SpawnEnemy.waves == 5)
        {
            spawnMiniBoss[0].SetActive(true);
            spawnGoblin[0].SetActive(true);
            spawnGoblin[1].SetActive(true);
        }else if (SpawnEnemy.waves == 6)
        {
            spawnBoss[0].SetActive(true);
            spawnBoss[1].SetActive(true);

        }
    }
}
