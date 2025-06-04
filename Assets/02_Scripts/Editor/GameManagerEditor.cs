using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GameManager))]
public class GameManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var manager = target as GameManager;

        EditorGUILayout.ObjectField("스크립트", MonoScript.FromMonoBehaviour(manager), typeof(MonoScript), false);

        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("적 생성"))
        {
            manager.SpawnEnemy();
        }

        if (GUILayout.Button("적 제거"))
        {
            var enemies = GameObject.FindGameObjectsWithTag("Enemy");

            foreach (var enemy in enemies)
            {
                DestroyImmediate(enemy);
            }
        }
        EditorGUILayout.EndHorizontal();
    }
}
