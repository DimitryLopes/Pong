using UnityEngine;
using System.Collections.Generic;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    [SerializeField]
    private UIScoreCounter p1Counter;
    [SerializeField]
    private UIScoreCounter p2Counter;

    public Dictionary<int, int> Scores = new Dictionary<int, int>();
    
    private void Awake()
    {
        Instance = this;
        Scores.Add(0, 0);
        Scores.Add(1, 0);
    }

    public void IncreasePlayerScore(int player)
    {
        Scores[player] += 1;
        UpdateScores();
        if(Scores[player] == 5)
        {
            GameManager.Instance.Finish(player);
        }
    }

    public void ShowHighScore(float p1, float p2)
    {
        p1Counter.ShowHighestScore(p1);
        p2Counter.ShowHighestScore(p2);
    }

    private void UpdateScores()
    {
        p1Counter.SetScore(Scores[0]);
        p2Counter.SetScore(Scores[1]);
    }

    public void ResetScore()
    {
        Scores[0] = 0;
        Scores[1] = 0;
        UpdateScores();
    }

}
