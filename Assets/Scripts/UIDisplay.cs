using System;
using UnityEngine;

public class UIDisplay : MonoBehaviour
{
    public static UIDisplay Instance { get; private set; }
    
    [SerializeField] GameObject winText;
    [SerializeField] GameObject loseText;

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
        winText.SetActive(false);
        loseText.SetActive(false);
    }
    
    public void DisplayWinText()
    {
        winText.SetActive(true);
    }
    
    public void DisplayLoseText()
    {
        loseText.SetActive(true);
    }
}
