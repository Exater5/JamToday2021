using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]List<bool> _taskStates;

    private void Start()
    {
        GameTaskEvents.completeTask.AddListener(CompleteTask);
    }

    public void CompleteTask(Tasks task)
    {
        _taskStates[(int)task] = true;
    }
}
