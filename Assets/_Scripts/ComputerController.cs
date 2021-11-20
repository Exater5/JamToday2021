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
            GameTaskEvents.completeTask.Invoke(0);
        }
        else
        {
            _meshRenderer.material = _offMat;
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
