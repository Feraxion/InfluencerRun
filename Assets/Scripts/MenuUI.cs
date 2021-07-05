using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    public GameManager gameMng;

    private void Start()
    {
        gameMng = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();

    }

    // Start is called before the first frame update
    public void PlayGame()
    {
        GameSceneManager.Load(GameSceneManager.Scene.Level1);
    }
    
    //OnClick Button
    public void StartGame()
    {
        gameMng.playerState = GameManager.PlayerState.Playing;
        gameMng.StartScreen.SetActive(false);
    }

    public void SkipLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //currentLevelDiamondCount = 0;
        gameMng.currentLevelDiamondCount = 0;
        gameMng.bonusMultiplier = 1;
    }

    public void RestartGame()
    {
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
    }
    
   
    
    public void ExitGame()
    { 
        Application.Quit();
    }
    
}
