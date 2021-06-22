using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCameraFollow : MonoBehaviour
{
    public FollowerManager followerMng;
    public Transform target;
    public int followerCount;
    public float smoothSpeed = 0.125f;

    public Vector3 offset;
    public Vector3 camFollowerPos;

    private void FixedUpdate()
    {
        followerCount = 1 * followerMng.activeFollowerAmount;
        camFollowerPos.z = followerCount * -0.07f;
        camFollowerPos.y = followerCount * 0.03f;
        //camFollowerPos.y = followerCount * 0.1f; +18 +19
        camFollowerPos.y = Mathf.Clamp(camFollowerPos.y, 0, 13);
        camFollowerPos.z = Mathf.Clamp(camFollowerPos.z, -18, 0);
        Vector3 desiredPosition = target.position + offset + camFollowerPos;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
        transform.LookAt(target);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
