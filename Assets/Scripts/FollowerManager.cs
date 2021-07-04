﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerManager : MonoBehaviour
{
    public int activeFollowerAmount;
    public int killFollowerAmount;
    public GameObject followerPrefab;

    public GameObject player;

    public List<GameObject> followerSpots;
    
    // Start is called before the first frame update
    void Start()
    {
        followerSpots = new List<GameObject>();
        followerSpots.AddRange(GameObject.FindGameObjectsWithTag("Spot"));
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddToFollowerList()
    {
        foreach (var spot in followerSpots)
        {
            Debug.Log("foreach calisiyor");
            if (spot.GetComponent<isSpotEmpty>().isEmpty)
            {

                    Debug.Log("if calisiyor");
                    
                Instantiate(followerPrefab, spot.transform.position, Quaternion.identity,spot.transform );
                spot.GetComponent<isSpotEmpty>().isEmpty = false;
                
                //follower.transform.position = spot.transform.position;
                activeFollowerAmount++;
                return;

            }

        }
    }
    
    // void addEnemy(GameObject currentEnemy) {
    //
    //     if(!enemies.Contains(currentEnemy))
    //         enemies.Add(currentEnemy);
    // }

    void KillFollowers()
    {
        activeFollowerAmount--;
    }
}
