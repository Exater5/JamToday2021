using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] List<bool> _taskStates;
    [SerializeField] CameraFollowChar _cameraFollowChar;
    private void Start()
    {
        _cameraFollowChar = FindObjectOfType<CameraFollowChar>();
        GameTaskEvents.completeTask.AddListener(CompleteTask);
    }

    public void CompleteTask(Tasks task)
    {
        _taskStates[(int)task] = true;
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
