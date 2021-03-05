﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemyTypes;
    private GameObject enemy;
    private GameManager gM;

    private void Start()
    {
        gM = FindObjectOfType<GameManager>();
        enemy =  Instantiate(enemyTypes[0], transform.position, Quaternion.identity);
    }
    // Update is called once per frame
    void Update()
    {
        if (enemy == null)
        {
            gM.enemiesDefeated++;
            switch (gM.enemiesDefeated)
            {
                case int n when (n < 9):
                    Instantiate(enemyTypes[0], transform.position, Quaternion.identity);
                    break;                     
                case int n when (n < 18):      
                    Instantiate(enemyTypes[1], transform.position, Quaternion.identity);   
                    break;                     
                case int n when (n < 27):      
                    Instantiate(enemyTypes[2], transform.position, Quaternion.identity);
                    break;                     
                case int n when (n < 36):      
                    Instantiate(enemyTypes[3], transform.position, Quaternion.identity);
                    break;                     
                case int n when (n >= 45):     
                    Instantiate(enemyTypes[4], transform.position, Quaternion.identity);
                    break;
            }
        }
    }
}
