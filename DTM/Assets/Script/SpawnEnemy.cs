using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemy;
    /*public GameObject miniBoss;
    public GameObject Boss;*/
    static int WhoSpawn;
    public static float waves = 1f;
    private float timeWaves = 60f;
    private float timePreparation = 30f;
    private bool isChange = false;
    public static bool isPreparation = false;
    private bool changeTime = false;
    private float countdown = 2f;
    public Text countingText;
    public Text conditionTime;
    // Start is called before the first frame update
    private void Update()
    {
        if(waves > 6)
        {
            Debug.Log("Finish");
            Time.timeScale = 0;
        }
        if (!isPreparation && countdown <= 0f)
        {
            if(changeTime)
            {
                CalculateWaves();
            }
            Debug.Log("IN");
            StartCoroutine(SpawnTime());
            countdown = 2f;
        }
        if (!isPreparation && timeWaves > 0f)
        {
            /*Debug.Log("timeWaves: " + timeWaves);*/
            timeWaves -= Time.deltaTime;
            conditionTime.text = "Waves " + waves;
            countingText.text = string.Format("{0:00.00}", timeWaves);
        } else if ((!isPreparation) && (timeWaves <= 0f))
        {
            isPreparation = true;
        }

        if (isPreparation && timePreparation > 0f)
        {
            Debug.Log("timeprepare: " + timePreparation);
            timePreparation -= Time.deltaTime;
            conditionTime.text = "Time Preparation";
            countingText.text = string.Format("{0:00.00}", timePreparation);
        } else if (isPreparation && (timePreparation <= 0f))
        {
            isPreparation = false;
            changeTime = true;
        }
        countdown -= Time.deltaTime;
    }
    // Spawn random ball at random x position at top of play area
    void SpawnRandomEnemy()
    {
        Debug.Log("Spawn");
        int WhoSpawn = Random.Range(0, 10);

        if (waves == 1 && WhoSpawn <= 5)
        {
            Instantiate(enemy, transform.position, enemy.transform.rotation);
        }else if(waves == 2 && WhoSpawn <= 2)
        {
            Instantiate(enemy, transform.position, enemy.transform.rotation);
        }else if (waves == 3 && WhoSpawn <= 5)
        {
            Instantiate(enemy, transform.position, enemy.transform.rotation);
        }else if (waves == 4 && WhoSpawn <= 3)
        {
            Instantiate(enemy, transform.position, enemy.transform.rotation);
        }else if(waves == 5 && WhoSpawn <= 1)
        {
            Instantiate(enemy, transform.position, enemy.transform.rotation);
        }else if(waves == 6 && WhoSpawn <= 1)
        {
            Instantiate(enemy, transform.position, enemy.transform.rotation);
        }
        
    }
    IEnumerator SpawnTime()
    {

        if (waves == 1 || waves == 3)
        {
            SpawnRandomEnemy();
            yield return new WaitForSeconds(Random.Range(1, 5));
        } else if(waves == 2 || waves == 4)
        {
            SpawnRandomEnemy();
            yield return new WaitForSeconds(Random.Range(6, 8));
        }else if (waves == 5)
        {
            SpawnRandomEnemy();
            yield return new WaitForSeconds(Random.Range(9, 10));
        }else if (waves == 6)
        {
            SpawnRandomEnemy();
            yield return new WaitForSeconds(Random.Range(9, 10));
        }
        
    }
    void CalculateWaves()
    {
        changeTime = false;
        waves += 1;
        timePreparation = 30f;
        timeWaves = 60f;
        Debug.Log("Waves: " + waves);
    }
}
