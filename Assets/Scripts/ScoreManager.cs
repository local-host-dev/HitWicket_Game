using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    private int score;

    private void Start()
    {
        score = 0;
        UpdateScore();
    }

    public void IncrementScore()
    {
        score++;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }
}
