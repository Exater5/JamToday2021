using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowController : MonoBehaviour
{
    private Animator _animator;
    private bool _currentState;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void SwapState()
    {
        _currentState = !_currentState;
        if (_currentState)
        {
            GameTaskEvents.completeConcreteTask.Invoke(new TaskClass(Tasks.Ventana, TaskFunction.Abrir));
        }
        else
        {
            GameTaskEvents.completeConcreteTask.Invoke(new TaskClass(Tasks.Ventana, TaskFunction.Cerrar));
        }
        _animator.SetBool("OpenWindow", _currentState);
    }
}
