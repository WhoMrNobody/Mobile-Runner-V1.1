using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LevelController : MonoBehaviour
{
    public static LevelController Current;
    public GameObject startMenu, gameMenu, gameOverMenu, finishMenu;
    public TMP_Text scoreText, finishScoreText, gameFinishScoreText;
    public int currentLevel;
    public const string HighScoreKey = "HighScore";
    public int score;

    void Start()
    {
        
        Current = this;
        currentLevel = PlayerPrefs.GetInt("currentLevel");
        scoreText.text="0";

    }

    public void StartLevel(){

        startMenu.SetActive(false);
        gameMenu.SetActive(true);
        PlayerController.Current.animator.SetBool("Running", true);
        GameManager.Instance.gameStatusValue=GameManager.GameStatus.PLAY;
    }

    public void RestartLevel(){
        
        LevelLoader.Current.ChangeLevel("Level " + PlayerPrefs.GetInt("currentLevel"));
        PlayerPrefs.SetInt(HighScoreKey, 0);
        GameManager.Instance.gameStatusValue=GameManager.GameStatus.NONE;
    }

    public void LoadNextLevel(){

        LevelLoader.Current.ChangeLevel("Level " + (currentLevel + 1));
        
    }

    public void GameOver(){
        
        PlayerPrefs.SetInt(HighScoreKey, 0);
        gameMenu.SetActive(false);
        gameOverMenu.SetActive(true);
        
    }

    public void FinishGame(){

        PlayerPrefs.SetInt("currentLevel", currentLevel + 1);
        PlayerPrefs.SetInt(HighScoreKey, score);
        finishScoreText.text = score.ToString();
        gameMenu.SetActive(false);
        finishMenu.SetActive(true);
        
    }

    public void ChangeScore(int increment){

        score += increment;
        scoreText.text = score.ToString();
        PlayerPrefs.SetInt(HighScoreKey, score);
        
    }

    

    public void BackToMainMenu(){

        PlayerPrefs.SetInt("currentLevel", 0);

        int currentHighScore = PlayerPrefs.GetInt(HighScoreKey);

        if(score>currentHighScore){

            PlayerPrefs.SetInt(HighScoreKey, score);
        
        }   

        SceneManager.LoadScene(0);
        

    }

    
}
