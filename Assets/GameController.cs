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
    public static int currentTaskIndex;
    private int _rightTasks, _failedTasks;



    private void Start()
    {
        _cameraFollowChar = FindObjectOfType<CameraFollowChar>();
        _instructionsGenerator = FindObjectOfType<InstructionsGenerator>();
        GameTaskEvents.completeConcreteTask.AddListener(CompleteTask);
    }

    public void ClearTasks()
    {
        for (int i = 0; i < _taskStates.Count; i++)
        {
            _taskStates[i] = false;
        }
    }

    public void CompleteTask(TaskClass taskClass)
    {
        _taskStates[(int)taskClass.task] = true;
        if (_instructionsGenerator.GetToDoTasksList()[currentTaskIndex].Contains(taskClass))
        {
            _rightTasks++;
            _scorePosTx.text = _rightTasks.ToString();
            currentTaskIndex++;
            _instructionsGenerator.OnNextTask();
        }
        else
        {
            _failedTasks++;
            _scoreNegTx.text = _failedTasks.ToString();
            FailTask();
        }
    }

    public bool CheckCompletedAllTasks()
    {
        bool completed = true;
        for (int i = 0; i < _instructionsGenerator.GetToDoTasksList()[currentTaskIndex].Count; i++)
        {
            if (!_taskStates[(int)_instructionsGenerator.GetToDoTasksList()[currentTaskIndex][i].task])
            {
                completed = false;
            }
        }
        return completed;
    }

    public void FailTask()
    {
        _instructionsGenerator.OnFailTask();
        _instructionsGenerator.OnNextTask();
        currentTaskIndex++;
        _cameraFollowChar.ShakeCamera(10, 1f);
    }
}
