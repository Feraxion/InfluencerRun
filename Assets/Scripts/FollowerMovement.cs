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
    
    
    // Start is called before the first frame update
    void Start()
    {
        
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
        if (other.gameObject.CompareTag("Player"))
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
