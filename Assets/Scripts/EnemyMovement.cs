using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyMovement : MonoBehaviour
{
    public bool attackPlayer;
    public Transform playerPos;
    public float moveSpeed;

    private int random;

    // Start is called before the first frame update
    void Start()
    {
        random = Random.Range(0, 5);
        
        switch (random)
        {
            case 0:
                playerPos = GameObject.FindGameObjectWithTag("Target").transform;
                break;
            case 1:
                playerPos = GameObject.FindGameObjectWithTag("Target1").transform;
                break;
            case 2:
                playerPos = GameObject.FindGameObjectWithTag("Target2").transform;
                break;
            case 3:
                playerPos = GameObject.FindGameObjectWithTag("Target3").transform;
                break;
            case 4:
                playerPos = GameObject.FindGameObjectWithTag("Target4").transform;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (attackPlayer)
        {
            float speed = moveSpeed * Time.deltaTime;

            transform.position = Vector3.MoveTowards(transform.position, playerPos.position, speed );
            transform.LookAt(playerPos);
            
            
        }
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
