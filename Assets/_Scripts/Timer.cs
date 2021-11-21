using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textTimer;
    [SerializeField] private GameController _gameController;
    private float _remainingTime;
    bool _counting;

    public void StartTimer(float seconds)
    {
        _counting = true;
        _remainingTime = seconds;
    }

    void Update()
    {
        if (_remainingTime > 0)
        {
            _remainingTime -= Time.deltaTime;
            float convertedTime = _remainingTime * 1000f;
            _textTimer.text = convertedTime.ToString("00:000");

        }
        else if(_counting)
        {
            _textTimer.text = "00:000";
            OnTimeOut();
            _counting = false;
        }
    }

    public void OnFailTask()
    {
        _textTimer.text = "00:000";
        _counting = false;
        _remainingTime = 0;
    }
    public void OnTimeOut()
    {
        _gameController.FailTask();
        _textTimer.text = "00:000";
        _counting = false;
    }
}