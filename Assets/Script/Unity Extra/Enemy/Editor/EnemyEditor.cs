using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Enemy))]
public class EnemyEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Enemy defaultEnemy = (Enemy)target;

        defaultEnemy.enemyAtack = EditorGUILayout.FloatField("Ataque ", defaultEnemy.enemyAtack);
        defaultEnemy.enemyEnergy = EditorGUILayout.FloatField("Energia ", defaultEnemy.enemyEnergy);
        defaultEnemy.enemyLife = EditorGUILayout.FloatField("Vida ", defaultEnemy.enemyLife);
        defaultEnemy.enemyScaleAtack = EditorGUILayout.FloatField("Indice de Escala Ataque ", defaultEnemy.enemyScaleAtack);
        defaultEnemy.enemyPrefab = (GameObject)EditorGUILayout.ObjectField(defaultEnemy.enemyPrefab, typeof(GameObject), true);

        EditorGUILayout.LabelField("Ataque Total", defaultEnemy.EnemyTotalAtack.ToString());

        if (defaultEnemy.EnemyTotalAtack > 30f)
        {
            EditorGUILayout.HelpBox("Ataque mais elevado do que o nível atual", MessageType.Error);
        }

        GUI.color = Color.yellow;

        if (GUILayout.Button("Create Enemy"))
        {
            defaultEnemy.CreateEnemy();
        }
    }
}
