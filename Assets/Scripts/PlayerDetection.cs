using System;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    Countdown _countdown;

    void Start()
    {
        _countdown = GetComponent<Countdown>();
    }

    void OnClick()
    {
        _countdown.AddToTimer();
    }
}
