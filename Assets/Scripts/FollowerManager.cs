using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerManager : MonoBehaviour
{
    public int activeFollowerAmount;
    public int killFollowerAmount;
  
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void KillFollowers()
    {
        activeFollowerAmount -= killFollowerAmount;
    }
}
