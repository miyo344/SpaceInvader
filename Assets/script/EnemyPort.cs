﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPort : MonoBehaviour
{
    [SerializeField] GameObject Enemy;
    [SerializeField] List<GameObject> EnemyList = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        SetNextEnemy();
    }

    void SetNextEnemy()
    {
        float interval = Random.Range(3f, 5f);
        Invoke("GenerateEnemy", interval);
    }

    //敵を生成する関数
    void GenerateEnemy()
    {
        int enemyindex = Random.Range(0, EnemyList.Count);
        GameObject enemy = Instantiate(EnemyList[enemyindex]);
        enemy.transform.position = this.transform.position;

        float x = Random.Range(-2.4f, 2.4f);
        Vector2 pos = enemy.transform.position;
        pos.x += x;
        enemy.transform.position = pos;

        //生成した敵の位置を、このEnemyPortの位置に調整
        SetNextEnemy();
    }
}
