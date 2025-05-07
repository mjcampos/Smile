using Unity.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    [Header("Timer Values")]
    [SerializeField] float timer = 10f;
    [SerializeField, ReadOnly] float timeRemaining;
    
    [Header("Slider")]
    [SerializeField] Slider slider;

    bool _timerStarted;
    int _lastWholeSecond;
    
    void Start()
    {
        timeRemaining = timer;
        
        slider.maxValue = timeRemaining;
        slider.value = timeRemaining;
        _timerStarted = true;
        _lastWholeSecond = Mathf.CeilToInt(timeRemaining);
    }

    void Update()
    {
        if (_timerStarted)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                slider.value = timeRemaining;
            }
            else
            {
                timeRemaining = 0f;
                slider.value = timeRemaining;
                _timerStarted = false;
            }
        }
    }

    public void NoticeIntegerChange()
    {
        int currentWholeSecond = Mathf.CeilToInt(timeRemaining);
        
        if (currentWholeSecond != _lastWholeSecond)
        {
            _lastWholeSecond = currentWholeSecond;
        }
    }

    public void AddToTimer()
    {
        if (!_timerStarted) return;
        
        timeRemaining = Mathf.Min(timeRemaining + 1f, slider.maxValue);
    }
}
