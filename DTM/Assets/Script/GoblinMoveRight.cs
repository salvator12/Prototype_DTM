using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinMoveRight : MonoBehaviour
{
    private Transform target;
    private Vector3 direction;
    Enemy enemy;
    private int wayPointIndex = 1;
    SpawnEnemy condition;
    /*    private bool changing = false;*/
    // Start is called before the first frame update
    void Start()
    {
        target = waypointsGoblin.points[1];
        enemy = GetComponent<Enemy>();
        condition = GetComponent<SpawnEnemy>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = target.position - transform.position;
        transform.Translate(direction.normalized * enemy.speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWayPoint();
        }
        enemy.speed = enemy.startSpeed;
    }
    
    void GetNextWayPoint()
    {
        /*if (condition.isPreparation)
        {
            Destroy(this.gameObject);
            return;
        }*/
        if ((wayPointIndex == 12) || (wayPointIndex == waypointsGoblin.points.Length - 1))
        {
            
            if (enemy != null)
            {
                enemy.AttackBase();
            }
            return;
        }

        if (wayPointIndex == 2)
        {
            // random untuk waypurple (inisial 1) atau wayred(1) (inisial 2)
            int choose = Random.Range(1, 3);
            if (choose == 1)
            {
                wayPointIndex += 6;

            }
            else if (choose == 2)
            {
                wayPointIndex += 11;
            }
            target = waypointsGoblin.points[wayPointIndex];
            /*Debug.Log(wayPointIndex);*/
        }
        else
        {
            wayPointIndex++;
            target = waypointsGoblin.points[wayPointIndex];
            /*Debug.Log(wayPointIndex);*/
        }

    }
}
