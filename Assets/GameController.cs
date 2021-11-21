using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField] List<bool> _taskStates;
    CameraFollowChar _cameraFollowChar;
    [SerializeField] TextMeshProUGUI _scorePosTx, _scoreNegTx;
    InstructionsGenerator _instructionsGenerator;
    private int _currentTaskIndex;
    private int _rightTasks, _failedTasks;



    private void Start()
    {
        _cameraFollowChar = FindObjectOfType<CameraFollowChar>();
        _instructionsGenerator = FindObjectOfType<InstructionsGenerator>();
        GameTaskEvents.completeTask.AddListener(CompleteTask);
    }

    public void ClearTasks()
    {
        _taskStates.Clear();
    }

    public void CompleteTask(Tasks task)
    {
        _taskStates[(int)task] = true;
        bool valid = false;
        foreach(Tasks t in _instructionsGenerator.GetToDoTasksList()[_currentTaskIndex])
        {
            if (t == task)
            {
                valid = true;
                if (CheckCompletedAllTasks())
                {
                    _rightTasks++;
                    _scorePosTx.text = _rightTasks.ToString();
                }
                break;
            }
        }
        if (!valid)
        {
            _failedTasks++;
            _scoreNegTx.text = _failedTasks.ToString();
            FailTask();
        }
    }

    public bool CheckCompletedAllTasks()
    {
        bool completed = true;
        for (int i = 0; i < _instructionsGenerator.GetToDoTasksList().Count; i++)
        {
            if (!_taskStates[(int)_instructionsGenerator.GetToDoTasksList()[_currentTaskIndex][i]])
            {
                completed = false;
            }
        }
        return completed;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            FailTask();
        }
    }

    public void FailTask()
    {
        _instructionsGenerator.OnFailTask();
        _cameraFollowChar.ShakeCamera(10, 1f);
    }
}
