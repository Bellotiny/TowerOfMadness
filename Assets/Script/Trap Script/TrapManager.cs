using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TrapManager : MonoBehaviour
{
    public static TrapManager Instance;
    public event Action<int> LiveChanged;
    public event Action OnGameOver;
    private int lives ;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            lives = 3;
            Debug.Log("TrapManager initialized successfully");
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    public void MinusLive()
    {
        lives--;
        LiveChanged?.Invoke(lives);
        Debug.Log("lives: " + lives);
        if(lives <= 0) 
        {
            OnGameOver?.Invoke();
        }
        
    }
    public void RestoreLives(){
        lives = 3;
        LiveChanged?.Invoke(lives);
    }
    public int GetLives() => lives;
}
