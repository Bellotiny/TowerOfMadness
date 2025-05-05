using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public event Action<int> OnFoodScoreChanged;
     private int levelScore = 0;
    private int totalScore = 0;

 
    private void Awake()
    {
        //Debug.Log(Instance == null);
        if(Instance == null){
            Debug.Log("score initialized successfully");
            DontDestroyOnLoad(gameObject);
            Instance = this;
        } 
        else {
            Destroy(gameObject);
        }
    }
    public void AddScore(int addScore){
        levelScore += addScore;
        totalScore += addScore;
        Debug.Log("levelScore: " + levelScore);
        OnFoodScoreChanged?.Invoke(totalScore);
    }
    public void SubtractScore()
    {
        totalScore -= levelScore;
        levelScore = 0;
        OnFoodScoreChanged?.Invoke(totalScore);
    }
   
    public int GetScore() => totalScore;

    public void SaveScore(){
        levelScore = 0; 
    }
    public void ResetScore(){
        totalScore = 0;
        levelScore = 0;
        OnFoodScoreChanged?.Invoke(totalScore);
    }
}
