using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerManager : MonoBehaviour
{
    public int activeFollowerAmount;
    public int killFollowerAmount;
    public GameObject followerPrefab;

    public GameObject player;

    public List<GameObject> followerSpots;
    public List<GameObject> followers;
    
    // Start is called before the first frame update
    void Start()
    {
        followerSpots = new List<GameObject>();
        followerSpots.AddRange(GameObject.FindGameObjectsWithTag("Spot"));
        
        //followers = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
       //  Debug.Log(followers.Count);
    }

    public void AddToFollowerList()
    {
        foreach (var spot in followerSpots)
        {
            if (spot.GetComponent<isSpotEmpty>().isEmpty)
            {

                    
                Instantiate(followerPrefab, spot.transform.position, Quaternion.identity,spot.transform );
                //followers.Add(followerPrefab.gameObject); 
                spot.GetComponent<isSpotEmpty>().isEmpty = false;
                
                //follower.transform.position = spot.transform.position;
                activeFollowerAmount++;
                return;

            }

        }
    }

    public void ArrengeFormation()
    {
        
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
