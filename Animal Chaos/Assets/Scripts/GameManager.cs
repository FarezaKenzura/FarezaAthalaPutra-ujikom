using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set;}

    [Header("Gameobject Reference")]
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject pausePanel;

    [Header("Camera Reference")]
    [SerializeField] private CinemachineVirtualCamera topCamera;
    [SerializeField] private CinemachineVirtualCamera downCamera;

    [Header("Score Properties")]
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text finalScoreText;
    [SerializeField] private int score; 

    [Header("Time Properties")]
    [SerializeField] private TMP_Text timeText;
    [SerializeField] private float timer;

    private bool isGameOver;
    private bool isPause;

    private void Awake() 
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }    

        Instance = this;
    }

    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPause) ResumeGame();
            else PauseGame();
        }

        if(isGameOver || isPause) return;

        UpdateTimer();
    }

    public void AddScore(int score)
    {
        this.score += score;
        scoreText.text = "Score: " + this.score;
        finalScoreText.text = "Final Score: " + this.score;
    }

    public void ReduceScore(int score)
    {
        this.score = Mathf.Max(0, this.score - score);
    }

    private void UpdateTimer()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
            timeText.text = "Timer: " + ((int)timer);
        }
        else
        {
            CameraSwitch();
        }
    }

    private void CameraSwitch()
    {
        topCamera.Priority = 0;
        downCamera.Priority = 10;

        GameOverPanel();
    }

    public void PauseGame()
    {
        pausePanel.SetActive(true);
        mainPanel.SetActive(false);
        gameOverPanel.SetActive(false);

        isGameOver = false;
        isPause = true;

        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        mainPanel.SetActive(true);
        gameOverPanel.SetActive(false);

        isGameOver = false;
        isPause = false;

        Time.timeScale = 1;
    }

    private void GameOverPanel()
    {
        gameOverPanel.SetActive(true);
        pausePanel.SetActive(false);
        mainPanel.SetActive(false);

        isGameOver = true;
        isPause = false;
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }
}
