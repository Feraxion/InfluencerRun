using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    public RowUI rowUI;
    public ScoreManager scoreManager;
    public bool scoreSet;

    private void Update()
    {
        if (GameManager.inst.playerState == GameManager.PlayerState.Finish && !scoreSet)
        {
            StartCoroutine(ExampleCoroutine());
            scoreSet = true;
        }
    }
    
    IEnumerator ExampleCoroutine()
    {
        
        //yield on a new YieldInstruction that waits for 5 seconds.
        scoreManager.GetHighScores();
            yield return new WaitForSeconds(3);
            scoreManager.AddScore(new Score("Cindy", 66));
            yield return new WaitForSeconds(1);
            scoreManager.AddScore(new Score("Elsa", 50));
            yield return new WaitForSeconds(1);
            scoreManager.AddScore(new Score("Olivia", 23));
            scoreManager.GetHighScores();

            yield return new WaitForSeconds(1);
            scoreManager.AddScore(new Score("Sophia", 38));
            yield return new WaitForSeconds(1);
            scoreManager.AddScore(new Score("Emma", 87));
            yield return new WaitForSeconds(1);
            scoreManager.AddScore(new Score("Isabella", 12));
        
        

        

    }

    private void Start()
    {
        



        var scores = scoreManager.GetHighScores().ToArray();
        for (int i = 0; i < scores.Length; i++)
        {
            var row = Instantiate(rowUI, transform).GetComponent<RowUI>();
            row.rank.text = (i + 1).ToString();
            row.name.text = scores[i].name;
            row.score.text = scores[i].score.ToString();
        }
    }
}
