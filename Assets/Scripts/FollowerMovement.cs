using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FollowerMovement : MonoBehaviour
{

    public Transform playerPos;
    public Transform behindPlayerPos;
    public bool followPlayer;
    public float moveSpeed;
    public Vector3 pos;
    public FollowerManager followerManager;
    private int random;
    
    
    // Start is called before the first frame update
    void Start()
    {
        random = Random.Range(0, 3);

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
                
        }

        
        followerManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<FollowerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (followPlayer)
        {
            
            float speed = moveSpeed * Time.deltaTime;

            transform.position = Vector3.MoveTowards(transform.position, playerPos.position, speed);

        }
    }

    void TransportBehindPlayer()
    {
        pos = playerPos.position;
        
        
        pos.z -= Random.Range(1.5f,5f);
        pos.x = Random.Range(-7f,2.2f);
        pos.y = 1.14f;

        transform.position = pos;

    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player") && !followPlayer)
        {
            TransportBehindPlayer();
            followPlayer = true;
            followerManager.activeFollowerAmount += 1;

        }

        if (other.gameObject.CompareTag("Obstacle"))
        {
            followerManager.activeFollowerAmount -= 1;
            Destroy(this.gameObject);
        }
    }

    
}
