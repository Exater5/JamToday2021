using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] List<bool> _taskStates;
    [SerializeField] CameraFollowChar _cameraFollowChar;
    InstructionsGenerator _instructionsGenerator;
    private int _currentTaskIndex;

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

                }
                break;
            }
        }
        if (!valid)
        {
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
        _cameraFollowChar.ShakeCamera(10, 1f);
    }
}
