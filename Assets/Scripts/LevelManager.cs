
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelManager : MonoBehaviour
{
    [SerializeField] int numberOfPlayerLives = 3;
    public static int score;
    public static int highScore;

    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI highScoreText;

    void Awake()
    {
        int numGameSessions = FindObjectsOfType<LevelManager>().Length;
        if (numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
        //DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", highScore);
        highScoreText.text = highScore.ToString();
        score = 0;
        livesText.text = numberOfPlayerLives.ToString();
        scoreText.text = score.ToString();
    }

    void Update()
    {
        if (score > highScore)
        {
            highScore = score;
            highScoreText.text = score.ToString();
            PlayerPrefs.SetInt("HighScore", highScore);
        }
    }

    public void PointsToScore(int coinsToScore)
    {
        score += coinsToScore;
        scoreText.text = score.ToString();      
    }

    public void RocketDestroy()
    {
        if (numberOfPlayerLives > 1)
        {
            ReduceLife();
        }
        else
        {
            GameOver();
        }
    }

    void ReduceLife()
    {
        numberOfPlayerLives--;
        int curretSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(curretSceneIndex);
        livesText.text = numberOfPlayerLives.ToString();      
    }

    public void IncreaseLife()
    {
        for (int i = 1; i < 4; i++)
        {
            if(numberOfPlayerLives == i)
            {
                numberOfPlayerLives = i + 1;
            }
        }
        //numberOfPlayerLives++;
        int curretSceneIndex = SceneManager.GetActiveScene().buildIndex;
        livesText.text = numberOfPlayerLives.ToString();
    }
    void GameOver()
    {
        Destroy(gameObject);
        FindObjectOfType<SceneBalance>().ResetSceneBalance();
        SceneManager.LoadScene(2);
    }
}
