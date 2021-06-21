using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private ScoreData scoreData;

    private void Awake()
    {
        PlayerPrefs.DeleteAll();
        var json = PlayerPrefs.GetString("scores", defaultValue: "{}");
        scoreData = JsonUtility.FromJson<ScoreData>(json);
    }

    public IEnumerable<Score> GetHighScores()
    {
        return scoreData.scores.OrderByDescending(x => x.score); // yükseliğe göre sıralama
    }

    public void AddScore(Score score)
    {
        scoreData.scores.Add(score);
    }

    private void OnDestroy()
    {
        SaveScore();
    }

    public void SaveScore()
    {
        var json = JsonUtility.ToJson(scoreData);
        PlayerPrefs.SetString("scores", json);
    }
}
