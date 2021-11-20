using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableInstance : MonoBehaviour
{
    [SerializeField] private int _taskType;
    [SerializeField] private ComputerController _computerController;
    [SerializeField] private WindowController _windowController;
    public void Interact()
    {
        Tasks task = (Tasks)_taskType;
        switch (task)
        {
            case Tasks.Ordenador:
                _computerController.TurnState();
                break;
            case Tasks.Ventana:
                _windowController.SwapState();
                break;
        }
    }
}
