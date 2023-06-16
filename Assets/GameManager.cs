using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;

    [SerializeField] private GameObject StartPanel;
    [SerializeField] private GameObject GameOverPanel;
    [SerializeField] private Text ScoreText;
    [SerializeField] private Text GameOverScoreText;

    public enum GameState {
        Start,
        Playing,
        GameOver
    }
    [HideInInspector] public GameState State;

    private int points;

    private void Awake() {
        Instance = this;
        Time.timeScale = 0f;
    }

    public void AddPoint() {
        points++;
        ScoreText.text = points.ToString();
    }

    public void StartGame() {
        State = GameState.Playing;
        StartPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void GameOver() {
        State = GameState.GameOver;
        GameOverScoreText.text = "Score: " + points;
        GameOverPanel.SetActive(true);
    }

    public void ResetGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}