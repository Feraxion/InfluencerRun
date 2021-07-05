using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public GameObject playerMesh;
    public float diamondPickUpScaleRate;
   // public Animator anim;
    public PlayerMovement pMov;
    public Camera finishCam;
    public ParticleSystem diaPoff;
    public FollowerManager followerManager;

    public GameManager gameMng;

    [Header("End Game Particle")]
    [SerializeField] public GameObject endGameParticle;
    [SerializeField] public GameObject nextLevelScreen;

    private void Start()
    {
        followerManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<FollowerManager>();

        //anim = gameObject.GetComponent<Animator>();
        //gameObject.GetComponent<Animator>().enabled = false;
        pMov = GetComponent<PlayerMovement>();
    }
    private void Update()
    {
    }
    
 
   


    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Finish"))
        {
            pMov.enabled = false;
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            StartCoroutine(ExampleCoroutine());
            //GameManager.inst.playerState = GameManager.PlayerState.Finish;
            //gameObject.GetComponent<Animator>().enabled = true;
            // anim.applyRootMotion = false;
            //anim.SetBool("Drift", true);
            //anim.SetTrigger("Drifter");

            //StartCoroutine(ExampleCoroutine());

            //3 saniyelik coroutine

            //anim.Play("CarAnim");

        } 
        
        if (col.gameObject.CompareTag("Enemy"))
        {
            //poof.GetComponent<ParticleSystem>().Play();
            followerManager.activeFollowerAmount -= 1;
            Destroy(col.gameObject);

            gameObject.GetComponent<CapsuleCollider>().enabled = false;
            Destroy(this.gameObject);
                    
        }

             
        if (col.gameObject.CompareTag("Obstacle"))
        {
            if (followerManager.activeFollowerAmount >0)
            {
                return;
            }
            else
            {
                gameMng.playerState = GameManager.PlayerState.Died;

            }
            
        }

        if (col.gameObject.CompareTag("EnemyInf"))
        {
            gameMng.playerState = GameManager.PlayerState.Finish;
            Destroy(col.gameObject);

        }
    }
    void NextLevel()
    {
        nextLevelScreen.SetActive(true);
        Destroy(this.gameObject);
    }

    IEnumerator ExampleCoroutine()
    {
        
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(4);
        gameMng.playerState = GameManager.PlayerState.Finish;


    }
}
