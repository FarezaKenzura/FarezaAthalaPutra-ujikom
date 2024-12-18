using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set;}

    [Header("Score Properties")]
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private int score; 

    [Header("Time Properties")]
    [SerializeField] private TMP_Text timeText;
    [SerializeField] private float timer;


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
        UpdateTimer();
    }

    public void AddScore(int score)
    {
        this.score += score;
        scoreText.text = "Score: " + this.score;
    }

    private void UpdateTimer()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
            timeText.text = "Timer: " + ((int)timer);
        }
    }
}
