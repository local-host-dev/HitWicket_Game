using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    private int score = 0;

    private void Start()
    {
        Debug.Log("Starting Coroutine");
        // Start the coroutine to update the score every 2 seconds
        StartCoroutine(UpdateScoreEveryTwoSeconds());
    }

    IEnumerator UpdateScoreEveryTwoSeconds()
    {
        while (true)
        {
            IncrementScore();
            yield return new WaitForSeconds(2.1f);
        }
    }

    private void IncrementScore()
    {
        score++;
        scoreText.text = "Score: " + score.ToString();
    }
}



// using UnityEngine;
// using UnityEngine.UI;
// using System.Collections;

// public class ScoreManager : MonoBehaviour
// {
//     public static ScoreManager Instance { get; private set; }
//     public Text scoreText;  // Reference to the UI Text element that displays the score
//     private int score = 0;  // Variable to store the current score

//     private void Awake()
//     {
//         // Ensure there is only one instance of the ScoreManager
//         if (Instance == null)
//         {
//             Instance = this;
//             DontDestroyOnLoad(gameObject);
//         }
//         else
//         {
//             Destroy(gameObject);
//         }

//         IncrementScore();
//     }


//     // Method to increment the score
//     public IEnumerator IncrementScore()
//     {
//         for(int i=0; i<100; i++)
//         {
//             Debug.Log("Score Incrementing");
//             score += 1;  // Increment the score by 1
//             UpdateScoreText();  // Update the score UI
//             yield return new WaitForSeconds(2);
//         }
//     }

//     // Method to update the score UI
//     void UpdateScoreText()
//     {
//         if (scoreText != null)
//         {
//             scoreText.text = "Score: " + score.ToString();
//             Debug.Log("Score updated to: " + score);  // Add this for debugging
//         }
//         else
//         {
//             Debug.LogError("ScoreText is not assigned!");  // Add this for error checking
//         }
//     }

// }
