using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Atributos Gerais")]
    public float enemyLife = 50f;
    public float enemyEnergy = 10f;
    public float enemyAtack = 5.5f;
    public float enemyScaleAtack = 1.3f;
    public GameObject enemyPrefab;

    public float EnemyTotalAtack
    {
        get { return enemyAtack * enemyScaleAtack; }
    }

    public void CreateEnemy()
    {
        var e = Instantiate(enemyPrefab);
        e.transform.position = Vector3.zero;
    }
}
