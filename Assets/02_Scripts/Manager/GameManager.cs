using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void SpawnEnemy()
    {
        for (int i = 0; i < 10; i++)
        {
            Vector2 pos2 = Random.insideUnitCircle.normalized * Random.Range(10.0f, 20.0f);
            Vector3 pos = new Vector3(pos2.x, 0, pos2.y);

            if (!Application.isPlaying)
            {
                player = GameObject.FindGameObjectWithTag("Player").transform;
            }

            Quaternion rot = Quaternion.LookRotation(player.position - pos);
            
            // Undo 기능 추가
            var enemy = Instantiate(enemyPrefab, pos, rot);
            Undo.RegisterCreatedObjectUndo(enemy, "Spawn Enemy");
        }
        
    }
}