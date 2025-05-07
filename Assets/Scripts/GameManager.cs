using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    Countdown _countdown;
    
    void Awake()
    {
        // Ensure only one instance exists
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
    }

    void Start()
    {
        _countdown = FindFirstObjectByType<Countdown>();
    }

    public void GameTimerReachedZero()
    {
        /*
         * If this method is triggered then player has won
         * 1. freeze slider
         * 2. Prevent player from clicking
         * 3. Display win text
         */
        
        /*
         * Step 1 - Calling countdown component stops the slider
         * Step 2 - Stopping the slider stops player clicking
         */
        if (_countdown)
        {
            _countdown.StopSlider();
        }
        
        // Step 3 - Display win text
        UIDisplay.Instance.DisplayWinText();
    }
}
