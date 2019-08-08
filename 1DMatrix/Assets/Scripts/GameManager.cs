using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text scoreText;
    public Text LivesText;
    public Text HighScoreText;

    void Start()
    {
        HighScoreText.text = PlayerPrefs.GetInt("Highscore", 0).ToString();
    }

    void Update()
    {
        scoreText.text = Bullet.score.ToString();
        LivesText.text = EnemyMovement.Lives.ToString();

        if (EnemyMovement.Lives < 1)
        {
            GameOver();
        }

        if(Bullet.score > PlayerPrefs.GetInt("Highscore", 0))
        {
            PlayerPrefs.SetInt("Highscore", Bullet.score);
            HighScoreText.text = PlayerPrefs.GetInt("Highscore", 0).ToString();
        }
    }

    void GameOver()
    {
        Bullet.score = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
