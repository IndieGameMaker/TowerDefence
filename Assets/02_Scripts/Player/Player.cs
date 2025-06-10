using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Player : MonoBehaviour
{

    void Update()
    {
        Enemy target = GetClosestEnemy();
        if (target != null)
        {
            transform.LookAt(target.transform.position);
        }
    }

    private Collider[] buffer = new Collider[50];
    
    private Enemy GetClosestEnemy()
    {
        // GC
        //Collider[] enemies = Physics.OverlapSphere(transform.position, 10.0f, 1 << 8);
        // GC
        //var enemiesList = enemies.OrderBy(enemy => Vector3.Distance(transform.position, enemy.transform.position)).ToList();
        //return (enemiesList.Count > 0) ? enemiesList[0].GetComponent<Enemy>() : null;

        int count = Physics.OverlapSphereNonAlloc(transform.position, 10.0f, buffer, 1 << 8);

        if (count == 0) return null;

        // 가장 가까이 있는 적 찾기위한 변수
        float minDistance = float.MaxValue;
        Enemy closestEnemy = null;
        
        for (int i = 0; i < count; i++)
        {
            if (buffer[i] == null) break;
            
            float distance = Vector3.Distance(transform.position, buffer[i].transform.position);
            if (distance < minDistance)
            {
                closestEnemy = buffer[i].GetComponent<Enemy>();
                minDistance = distance;
            }
        }

        return closestEnemy;

    }
}
