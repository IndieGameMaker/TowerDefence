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

    private Enemy GetClosestEnemy()
    {
        // GC
        Collider[] enemies = Physics.OverlapSphere(transform.position, 10.0f, 1 << 8);

        // GC
        var enemiesList = enemies.OrderBy(enemy => Vector3.Distance(transform.position, enemy.transform.position))
            .ToList();
        
        return (enemiesList.Count > 0) ? enemiesList[0].GetComponent<Enemy>() : null;
    }
}
