using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMoveLeft : MonoBehaviour
{
    private Transform target;
    Enemy enemy;
    SpawnEnemy condition;
    private int wayPointIndex = 0;
/*    private bool changing = false;*/
    // Start is called before the first frame update
    void Start()
    {
        target = waypointsBoss.points[0];
        enemy = GetComponent<Enemy>();
        condition = GetComponent<SpawnEnemy>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * enemy.speed * Time.deltaTime);
        
        if(Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWayPoint();
        }
        enemy.speed = enemy.startSpeed;
    }

   void GetNextWayPoint()
    {
        /*if(condition.isPreparation)
        {
            Destroy(this.gameObject);
            return;
        }*/
        if((wayPointIndex == 7) || (wayPointIndex == 12))
        {
            if (enemy != null)
            {
                enemy.AttackBase();
            }
            return;
        }
        
        if (wayPointIndex == 0)
        {
            // random untuk wayblue(1) (inisial 1) atau waypurple (inisial 2)
            int choose = Random.Range(1, 3);
            if(choose == 1)
            {
                wayPointIndex+= 3;

            } else if(choose == 2)
            {
                wayPointIndex += 8;
            }
            target = waypointsBoss.points[wayPointIndex];
            /*Debug.Log(wayPointIndex);*/
        } 
        else
        {
            wayPointIndex++;
            target = waypointsBoss.points[wayPointIndex];
            /*Debug.Log(wayPointIndex);*/
        }
        
    }
}
