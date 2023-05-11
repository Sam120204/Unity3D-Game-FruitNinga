using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Game Over")]
    public GameObject gameOverPanel;
    public TextMeshProUGUI gameOverScoreText;
    [Header("Score Element")]
    public int score = 0;
    public TextMeshProUGUI scoreText;
    public int bestScore = 0;
    public TextMeshProUGUI bestScoreText;

    public void IncreaseScore()
    {
        score += 1;
        if(score > bestScore)
        {
            PlayerPrefs.SetInt("BestScore", score);
            bestScoreText.text = "Best: " + bestScore.ToString();
        }
        scoreText.text = score.ToString();
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
        gameOverScoreText.text = "Score: " + score.ToString();
    }

    public void GameRestart()
    {
        Time.timeScale = 1;
        score = 0;
        scoreText.text = "0";
        bestScore = PlayerPrefs.GetInt("BestScore");
        bestScoreText.text = "Best: " + bestScore.ToString();
        gameOverPanel.SetActive(false);
        foreach(GameObject obj in GameObject.FindGameObjectsWithTag("interactable"))
        {
            Destroy(obj);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        gameOverPanel.SetActive(false);
        bestScore = PlayerPrefs.GetInt("BestScore");
        bestScoreText.text = "Best: " + bestScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
