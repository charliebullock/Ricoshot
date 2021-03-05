using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    //Variables
    #region variables    

    public float enemySpeed;
    private GameObject player;
    private GameManager gM;
    #endregion variables  

    //Start function for assigning variable values and setting a navmesh up
    private void Start()
    {
        gM = FindObjectOfType<GameManager>();
        player = GameObject.FindGameObjectWithTag("Player");
        NavMeshAgent navmesh = GetComponent<UnityEngine.AI.NavMeshAgent>();
        navmesh.SetDestination(player.transform.position);
        navmesh.speed = enemySpeed;
        switch (gM.enemiesDefeated)
        {
            case int n when (n < 9):
                break;
            case int n when (n < 18):
                navmesh.speed = enemySpeed * 1.25f;
                break;
            case int n when (n < 27):
                navmesh.speed = enemySpeed * 1.5f;
                break;
            case int n when (n < 36):
                navmesh.speed = enemySpeed * 1.75f;
                break;
            case int n when (n < 45):
                navmesh.speed = enemySpeed * 2f;
                break;
            case int n when (n < 54):
                navmesh.speed = enemySpeed * 2.5f;
                break;
            case int n when (n < 63):
                navmesh.speed = enemySpeed * 3f;
                break;
            case int n when (n < 72):
                navmesh.speed = enemySpeed * 4f;
                break;
            case int n when (n < 81):
                navmesh.speed = enemySpeed * 5f;
                break;
            case int n when (n >= 81):
                navmesh.speed = enemySpeed * 6f;
                break;
        }
    }

    //Update function to set the speed correctly, checking and setting the speed up correctly after player dies
    public void Update()
    {
        if (gameObject.GetComponent<NavMeshAgent>() != null)
        {
            if (gameObject.GetComponent<NavMeshAgent>().speed != enemySpeed)
            {
                gameObject.GetComponent<NavMeshAgent>().speed = enemySpeed;
            }
        }

        //If this enemy is close to the player then deduct health off them
        if (Vector3.Distance(player.transform.position, transform.position) <= 1)
        {
            Debug.Log("PlayerKilled");
            Destroy(gameObject);
            gM.Reset();
        }
    }

}
