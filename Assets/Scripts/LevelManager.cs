
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelManager : MonoBehaviour
{
    [SerializeField] int numberOfPlayerLives = 3;
    [SerializeField] int score = 0;

    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI scoreText;

    void Awake()
    {
        int numGameSessions = FindObjectsOfType<LevelManager>().Length;
        if(numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
        
    }
    void Start()
    {
        livesText.text = numberOfPlayerLives.ToString();
        scoreText.text = score.ToString();
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
            ReloadGame();
        }
    }

    void ReduceLife()
    {
        numberOfPlayerLives--;

        int curretSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(curretSceneIndex);

        livesText.text = numberOfPlayerLives.ToString();
        Debug.Log(numberOfPlayerLives);
        
    }

    public void IncreaseLife()
    {
        numberOfPlayerLives++;
        int curretSceneIndex = SceneManager.GetActiveScene().buildIndex;
        livesText.text = numberOfPlayerLives.ToString();
    }
    void ReloadGame()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
}
