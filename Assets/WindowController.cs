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
        GameTaskEvents.completeTask.Invoke(Tasks.Ventana);
        _currentState = !_currentState;
        _animator.SetBool("OpenWindow", _currentState);
    }
}
