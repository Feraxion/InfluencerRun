using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform[] targets;
    public Rigidbody m_Rigidbody;
    [Header("Speed Settings")]
    public float movementSpeed;
    public float controlSpeed;
    

    //Touch settings
    [Header("Touch Settings")]
    [SerializeField] bool isTouching;
    public float touchPosX,minX,maxX;
    Vector3 direction;

    //Animation
    //public Animator animator;
    
    //Not sure about this// Getting playerstate from gamemanager
    public GameManager.PlayerState playerState;
    public GameManager gameMng;

    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();


    }

    private void Start()
    {
        gameMng = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        
    }

    private void Update()
    {
        
            playerState =  gameMng.playerState ;

        
        
    }

       
    

    private void FixedUpdate()
    {
        //Start game if in Playing State
        if (playerState == GameManager.PlayerState.Playing)
        {
            GetInput();

            //RigidBody Eklentisinden sonra burası rigidbody olarak değişecek
            //m_Rigidbody.AddForce(transform.forward * movementSpeed);
            //transform.position += m_Rigidbody.AddForce(transform.forward * movementSpeed);
            transform.position += Vector3.forward * movementSpeed * Time.fixedDeltaTime;
           // m_Rigidbody.velocity = Vector3.forward * movementSpeed;
            //animator.SetTrigger("GameStart"); // start the animation
            //m_Rigidbody.AddForce(Vector3.forward * movementSpeed * Time.fixedDeltaTime);
            if (isTouching)
            {
                touchPosX += Input.GetAxis("Mouse X") * controlSpeed * Time.fixedDeltaTime;
            }

            transform.position = new Vector3(touchPosX, transform.position.y, transform.position.z);
            touchPosX = Mathf.Clamp(touchPosX, minX, maxX);
        }
        
    }
    //Testing Inputs
    void GetInput()
    {
        if (Input.GetMouseButton(0))
        {
            isTouching = true;
        }
        else
        {
            isTouching = false;
        }
    }
    //Mobile Inputs
    void GetInputMobile()
    {
        if (Input.touchCount > 0)
        {
            isTouching = true;
        }
        else
        {
            isTouching = false;
        }
    }
    
    

    private void OnTriggerEnter(Collider other)
    {
        /*if (other.gameObject.CompareTag("EnemyTrigger"))
        {
            
            for (int i = 0; i < targets.Length; i++)
            {
                Vector3 plusPos = targets[i].transform.position;
                plusPos.z += 5f;
                targets[i].transform.position = plusPos;
                Debug.Log("Works");
            }

            movementSpeed -= 5f;

            StartCoroutine(WaitSecRoutine());
        }*/
    }
    
    IEnumerator WaitSecRoutine()
    {
       
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(3);
        movementSpeed += 5f;

        for (int i = 0; i < targets.Length; i++)
        {
            Vector3 plusPos = targets[i].transform.position;
            plusPos.z -= 5f;
            targets[i].transform.position = plusPos;
            
            
        }

    }
    
}
