using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isSpotEmpty : MonoBehaviour
{
    public bool isEmpty;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount == 0)
        {
            isEmpty = true;
        }
        else
        {
            isEmpty = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Follower"))
        {
            isEmpty = false;
            Debug.Log("girdi");
    
        }
    }

    


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Follower"))
        {
            isEmpty = true;
                Debug.Log("cikti");
        }
    }
}
