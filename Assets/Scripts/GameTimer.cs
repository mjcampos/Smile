using System;
using TMPro;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI countdownText;
    [SerializeField] float totalTime = 20f;
    
    float _timeRemaining;
    int _lastDisplayedSecond;
    
    void Start()
    {
        _timeRemaining = totalTime;
        _lastDisplayedSecond = Mathf.CeilToInt(_timeRemaining);
        countdownText.text = _lastDisplayedSecond.ToString();
    }

    void Update()
    {
        if (_timeRemaining > 0)
        {
            _timeRemaining -= Time.deltaTime;
            int currentSecond = Mathf.CeilToInt(_timeRemaining);

            if (currentSecond < _lastDisplayedSecond)
            {
                _lastDisplayedSecond = currentSecond;
                countdownText.text = _lastDisplayedSecond.ToString();
            }
        }
        else
        {
            GameManager.Instance.GameTimerReachedZero();
        }
    }
}
