using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textTimer;
    private float _remainingTime;

    public void StartTimer(float seconds)
    {
        _remainingTime = seconds;
    }

    void Update()
    {
        if (_remainingTime >= 0)
        {
            _remainingTime -= Time.deltaTime;
            float convertedTime = _remainingTime * 1000f;
            _textTimer.text = convertedTime.ToString("00:000");

        }
        else
        {
            _textTimer.text = "00:000";
        }

        if (Input.GetKeyDown(KeyCode.Space)) { StartTimer(5); }
    }
}