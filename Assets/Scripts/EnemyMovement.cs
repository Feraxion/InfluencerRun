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
    public ParticleSystem poof;
    private int random;
    public Vector3 lastPos;
    public bool destroyedOnce;

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
            lastPos=transform.rotation.eulerAngles;
            
            lastPos.z = 0f;
            
            transform.rotation = Quaternion.Euler(lastPos);
            
            float speed = moveSpeed * Time.deltaTime;

            transform.position = Vector3.MoveTowards(transform.position, playerPos.position, speed );
            transform.LookAt(playerPos);
            
            
        }
        
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!destroyedOnce)
        {
            // if (other.gameObject.CompareTag("Player"))
            // {
            //     destroyedOnce = true;
            //
            //     poof.Play();
            //     
            //     Destroy(gameObject,0.2f);
            //
            // }
        
            if (other.gameObject.CompareTag("Follower"))
            {
                destroyedOnce = true;
                Debug.Log("yoketti");

                poof.Play();
                Destroy(gameObject,0.2f);
                Destroy(other.gameObject,3f);

                other.gameObject.SetActive(false);

            }
        }
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            poof.Play();
            Destroy(gameObject);
        }
        
        if (other.CompareTag("Follower"))
        {
            poof.Play();
            Destroy(gameObject);
        }
    }
}
