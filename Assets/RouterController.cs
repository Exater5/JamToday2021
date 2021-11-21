using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouterController : MonoBehaviour
{
    private bool _state;

    [SerializeField] Animator _animator;

    public void SwapState()
    {
        _state = !_state;
        if (_state)
        {
            GameTaskEvents.completeConcreteTask.Invoke(new TaskClass(Tasks.Router, TaskFunction.Abrir));
        }
        else
        {
            GameTaskEvents.completeConcreteTask.Invoke(new TaskClass(Tasks.Router, TaskFunction.Cerrar));
        }
        _animator.SetBool("RouterState", _state);
    }
}
