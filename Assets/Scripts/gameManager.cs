using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class gameManager : MonoBehaviour
{
    int score;
    int lives;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public bool gameIsOver;
    public static gameManager Instance { get; private set; }
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        lives = 3;
    }

    public void UpdateTheScore(int scorePiontsToAdd)
    {
        score += scorePiontsToAdd;
        scoreText.text = score.ToString();
    }

    public void UpdateLives()
    {
        if (gameIsOver == false)
        {
            lives--;
            livesText.text = "Lives :" + lives;
            if (lives <= 0)
            {
                GameOver();
            }
        }
        
    }

    public void GameOver()
    {
        gameIsOver = true;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);

    }


    public void RestartTheGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
