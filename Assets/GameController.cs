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
        bool correct = false;
        foreach (TaskClass tC in _instructionsGenerator.GetToDoTasksList()[currentTaskIndex])
        {
            if(tC.task == taskClass.task)
            {
                if (tC.taskFunction == taskClass.taskFunction)
                {
                    correct = true;
                    break;
                }
            }
        }
        if (correct)
        {
            _taskStates[(int)taskClass.task] = true;
            if (CheckCompletedAllCurrentTasks())
            {
                _rightTasks++;
                _scorePosTx.text = _rightTasks.ToString();
                currentTaskIndex++;
                FindObjectOfType<Timer>().OnCompleteTask();
                ClearTasks();
                if (_instructionsGenerator.GetTaskAmount() == currentTaskIndex)
                {
                    FindObjectOfType<SimpleSampleCharacterControl>().Saluda();
                    GameFlowEvents.LoadScene.Invoke("MainMenu");
                }
                else
                {
                    _instructionsGenerator.OnNextTask();
                }
            }
        }
        else
        {
            _failedTasks++;
            _scoreNegTx.text = _failedTasks.ToString();
            ClearTasks();
            FailTask();
        }
    }

    public bool CheckCompletedAllCurrentTasks()
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
