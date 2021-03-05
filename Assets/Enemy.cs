using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    //Variables
    #region variables    
    [SerializeField]
    private bool bIsFastEnemy;
    public float fEnemySpeed;
    [SerializeField]
    private Transform positionalReset;
    private GameObject player;
    #endregion variables  

    //Start function for assigning variable values and setting a navmesh up
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gameObject.transform.position = positionalReset.position;
        if (bIsFastEnemy)
        {
            fEnemySpeed = 0.5f;
        }
        NavMeshAgent navmesh = GetComponent<UnityEngine.AI.NavMeshAgent>();
        navmesh.SetDestination(player.transform.position);
        navmesh.speed = fEnemySpeed;
    }

    //Update function to set the speed correctly, checking and setting the speed up correctly after player dies
    public void Update()
    {
        if (gameObject.GetComponent<NavMeshAgent>() != null)
        {
            if (gameObject.GetComponent<NavMeshAgent>().speed != fEnemySpeed)
            {
                gameObject.GetComponent<NavMeshAgent>().speed = fEnemySpeed;
            }
        }

        //If this enemy is close to the player then deduct health off them
        if (Vector3.Distance(player.transform.position, transform.position) <= 1)
        {
            Debug.Log("PlayerKilled");
        }
    }

}
