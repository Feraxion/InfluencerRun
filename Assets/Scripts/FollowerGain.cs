using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerGain : MonoBehaviour
{
    
    public Transform playerPos;
    public Transform behindPlayerPos;
    public bool followPlayer;
    public float moveSpeed;
    public Vector3 pos;
    public FollowerManager followerManager;
    public GameObject followerGO;

    
    // Start is called before the first frame update
    void Start()
    {
        playerPos = gameObject.transform;
        followerManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<FollowerManager>();

        followerGO = followerManager.followerPrefab;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Multiply"))
        {
           int multiplier = other.GetComponent<MultiplyInfo>().multiplier;
           bool multiply = other.GetComponent<MultiplyInfo>().isMultiply;

           if (multiply)
           {
               
                       
                       for (int i = 0; i < multiplier * followerManager.activeFollowerAmount; i++)
                       {
                           // pos = playerPos.position;
                           //
                           //
                           // pos.z -= Random.Range(1.5f,5f);
                           // pos.x = Random.Range(-7f,2.2f);
                           // pos.y = 1.14f;
                       
                            Debug.Log("calsiyur");
                           followerManager.AddToFollowerList();
                       }




                       // followerManager.activeFollowerAmount += multiplier * followerManager.activeFollowerAmount;
           }
           else
           {
               for (int i = 0; i < multiplier; i++)
               {
                   // pos = playerPos.position;
                   //
                   //
                   // pos.z -= Random.Range(1.5f,5f);
                   // pos.x = Random.Range(-7f,2.2f);
                   // pos.y = 1.14f;
                   //     
                       
                   followerManager.AddToFollowerList();
                   Debug.Log("calsiyur");
                    

                   
               }
               
               //followerManager.activeFollowerAmount += multiplier;
               

           }
           
           other.gameObject.GetComponent<BoxCollider>().enabled = false;


        }
    }
}
