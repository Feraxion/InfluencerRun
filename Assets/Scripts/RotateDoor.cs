using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateDoor : MonoBehaviour
{
    public int rotateLeftDegree,rotateRightDegree;
    public Vector3 leftVector, rightVector;

    // public int leftDoorDegree,rightDoorDegree;
    //
    // public int smooth;
    public bool openDoor;
    public float rotSpeed;
    private float leftRotateSpeed, rightRotateSpeed;
    
    public GameObject doorRight, doorLeft;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if (doorLeft.transform.rotation.eulerAngles.y >= rotateLeftDegree -1)
        {
            leftRotateSpeed = -rotSpeed;
            rightRotateSpeed = -rotSpeed;
        }

        if (doorLeft.transform.rotation.eulerAngles.y <= 0 )
        {
            leftRotateSpeed = rotSpeed * -1f;
            rightRotateSpeed = rotSpeed;
        }
       
            // rotateLeftDegree = new Vector3(0, leftDoorDegree, 0);
            // rotateRightDegree = new Vector3(0, rightDoorDegree, 0);
            // rotateLeft = Quaternion.FromToRotation(doorLeft.transform.eulerAngles, rotateLeftDegree);
            // rotateRight = Quaternion.FromToRotation(doorRight.transform.eulerAngles, rotateRightDegree);
            //
            // doorLeft.transform.rotation = Quaternion.Lerp(doorLeft.transform.rotation, rotateLeft, Time.deltaTime * smooth);
            // doorRight.transform.rotation = Quaternion.Lerp(doorRight.transform.rotation, rotateRight, Time.deltaTime * smooth);
            if (openDoor)
            {
                //
                // doorLeft.transform.Rotate(0f, rotateLeftDegree * Time.deltaTime ,0 , Space.Self);
                // doorRight.transform.Rotate(0f, rotateRightDegree * Time.deltaTime , 0, Space.Self);
                //
                // leftVector = doorLeft.transform.rotation.eulerAngles;
                // rightVector = doorRight.transform.rotation.eulerAngles;
                //     
                //  //leftVector.y = Mathf.Clamp(doorLeft.transform.rotation.eulerAngles.y, 0, rotateRightDegree);
                //
                //  doorLeft.transform.rotation = Quaternion.Euler(leftVector);
                //  d
                
                Vector3 rot = doorLeft.transform.rotation.eulerAngles - new Vector3(0, -leftRotateSpeed * Time.deltaTime, 0f); //use local if your char is not always oriented Vector3.up
                Vector3 rot2 = doorRight.transform.rotation.eulerAngles - new Vector3(0, rightRotateSpeed * Time.deltaTime, 0f); //use local if your char is not always oriented Vector3.up

        
                //rot.y = ClampAngle(rot.y, rotateLeftDegree, 0 + 1);
                rot2.y = ClampAngle(rot2.y, -15, rotateRightDegree - 1);

                if (rot2.y > rotateRightDegree-2)
                {
                    openDoor = false;
                }

        
         
                doorLeft.transform.eulerAngles = rot;
                doorRight.transform.eulerAngles = rot2;

                 

                 /*rotateLeftDegree = doorLeft.transform.rotation.eulerAngles;
                 rotateRightDegree = doorRight.transform.rotation.eulerAngles;
             
                 
                     rotateLeftDegree.y -= smooth;
                     rotateRightDegree.y += smooth;
                 
 
         
                 doorLeft.transform.rotation = Quaternion.Euler(0,0,0);
                 doorRight.transform.rotation = Quaternion.Euler(rotateRightDegree);*/
            }
            


    }
    
     float ClampAngle(float angle, float from, float to)
        {
            // accepts e.g. -80, 80
            if (angle < 0f) angle = 360 + angle;
            if (angle > 180f) return Mathf.Max(angle, 360+from);
            return Mathf.Min(angle, to);
        }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            openDoor = true;


        }
    }
}
