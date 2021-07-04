using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyInfMovement : MonoBehaviour
{
    public bool attackPlayer;
    public Transform playerPos;
    public float moveSpeed;
    public Animator anim;
    public Vector3 lastPos;

    private int random;

    // Start is called before the first frame update
    void Start()
    {
        if (!GetComponent<Animator>() == null)
        {
            anim = GetComponent<Animator>();

        }
        
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
            
            if (!anim.GetBool("isAttacking"))
            {
                anim.SetBool("isAttacking",true);

            }
        }
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
