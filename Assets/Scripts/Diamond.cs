using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    public GameManager gameMng;

    private void Start()
    {
        gameMng = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        poff = GetComponentInChildren<ParticleSystem>();

    }

    [Header("Diamond Components")]
    [SerializeField] public float turnSpeed = 90f;

    public ParticleSystem poff;
    private void OnTriggerEnter(Collider col)
    {
        // check that the object we collided with is the player
        if (col.gameObject.CompareTag("Player"))
        {
            poff.Play();
            // Add to the player's diamond 
            gameMng.IncrementDiamond();
            //Destroy the diamond object
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            Destroy(gameObject,3);
            
        }
       
    }

     void Update()
    {
        transform.Rotate(0, 0, turnSpeed * Time.deltaTime);
    }
}
