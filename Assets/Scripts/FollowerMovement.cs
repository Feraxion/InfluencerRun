using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FollowerMovement : MonoBehaviour
{
    public Transform player;

    public Transform playerPos;
    public Transform behindPlayerPos;
    public bool followPlayer;
    public float moveSpeed;
    public Vector3 pos;
    public FollowerManager followerManager;
    private int random;
    public bool isMoving;

    private Rigidbody m_Rigidbody;

    
    
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

                // transform.rotation = Quaternion.Euler(-90, 0, 90); // rotasyonları prefab'de düzgün olmasına rağmen bozuk geliyodu -aybars     

        }

        player = GameObject.FindGameObjectWithTag("LookAt").transform;

        followerManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<FollowerManager>();
        m_Rigidbody = gameObject.GetComponent<Rigidbody>();
    }
    
    
    public float smoothTime = 0.3F;
    private float yVelocity = 0.0F;
    
            // Update is called once per frame
            void FixedUpdate()
            {
                if (followPlayer )
                {
                  
                        float speed = moveSpeed  * Time.fixedDeltaTime;
    
                        transform.position = Vector3.MoveTowards(transform.position, playerPos.position, speed);
                        //m_Rigidbody.velocity = Vector3.forward * speed;
                        //transform.position = Vector3.Lerp(transform.position, playerPos.position, speed);
                        //transform.LookAt(player);
                        //float newPosition = Mathf.SmoothDamp(transform.position.z, playerPos.position.z, ref yVelocity, smoothTime);
                       // transform.position = new Vector3(transform.position.x, newPosition, transform.position.z);                        // if(transform.position == playerPos.position)
                        // {
                        //     isMoving = false;
                        //
                        //     // So in order to eliminate any remaining difference
                        //     // make sure to set it to the correct target position
                        //     transform.position = playerPos.position;
                        // }
                        
                        // move follower //
                    



                        // var distance = Vector3.Distance(transform.position, playerPos.position);
                        //
                        //
                        // if (distance <1.5f)
                        // {
                        //     isMoving = true;
                        // }
                }
                
                
            }
            
    
            void TransportBehindPlayer()
            {
                pos = playerPos.position;
    
    
                pos.z -= Random.Range(1.5f, 5f);
                pos.x = Random.Range(-7f, 2.2f);
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
    
                if (other.gameObject.CompareTag("Enemy"))
                {
                    followerManager.activeFollowerAmount -= 1;
                    Destroy(this.gameObject);
                    Destroy(other.gameObject);
                }

                if (other.gameObject.CompareTag("EnemyInf"))
                {
                    followerManager.activeFollowerAmount -= 1;
                    Destroy(this.gameObject);
                    Destroy(other.gameObject);
                    GameManager.inst.playerState = GameManager.PlayerState.Finish;

                }
            }

            private void OnCollisionExit(Collision other)
            {
                
            }

            private void OnTriggerEnter(Collider other)
            {
                if (other.gameObject.CompareTag("Obstacle"))
                {
                    followerManager.activeFollowerAmount -= 1;
                    Destroy(this.gameObject);
                }
    
                if (other.gameObject.CompareTag("Enemy"))
                {
                    followerManager.activeFollowerAmount -= 1;
                    
                    
                    Destroy(this.gameObject,4);
                    Destroy(other.gameObject);
                }
                
                if (other.gameObject.CompareTag("EnemyInf"))
                {
                    followerManager.activeFollowerAmount -= 1;
                    Destroy(this.gameObject);
                    Destroy(other.gameObject);
                    GameManager.inst.playerState = GameManager.PlayerState.Finish;

                }
            }
}
