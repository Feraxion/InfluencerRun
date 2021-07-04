using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{

    public EnemyMovement[] enemy;
    public EnemyInfMovement enemyInf;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            for (int i = 0; i < enemy.Length; i++)
            {
                enemy[i].attackPlayer = true;
            }

            if (enemyInf == null)
            {
            }
            else
            {
                enemyInf.attackPlayer = true;

            }
            
            Destroy(this.gameObject,2);

        }
    }
}
