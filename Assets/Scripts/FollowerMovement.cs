using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerMovement : MonoBehaviour
{

    public Transform playerPos;
    public Transform behindPlayerPos;
    public bool followPlayer;
    public float moveSpeed;
    public Vector3 pos;
    
    
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
        
        pos.z -= 4f;

        transform.position = pos;

    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            TransportBehindPlayer();
            followPlayer = true;
            
        }    
    }
}
