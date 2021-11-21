using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerController : MonoBehaviour
{
    [SerializeField] private Material _offMat, _onMat;
    [SerializeField] private MeshRenderer _meshRenderer;
    bool _currentState;

    public void TurnState()
    {
        _currentState = !_currentState;
        if (_currentState)
        {
            _meshRenderer.material = _onMat;
            GameTaskEvents.completeConcreteTask.Invoke(new TaskClass(Tasks.Ordenador, TaskFunction.Abrir));
        }
        else
        {
            _meshRenderer.material = _offMat;
            GameTaskEvents.completeConcreteTask.Invoke(new TaskClass(Tasks.Ordenador, TaskFunction.Cerrar));
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            TurnState();
        }
    }
}
