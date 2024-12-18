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
        if(isGameOver) return;

        UpdateTimer();
    }

    public void AddScore(int score)
    {
        this.score += score;
        scoreText.text = "Score: " + this.score;
        finalScoreText.text = "Final Score: " + this.score;
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

    private void GameOverPanel()
    {
        gameOverPanel.SetActive(true);
        mainPanel.SetActive(false);

        isGameOver = true;
    }
}
