using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableInstance : MonoBehaviour
{
    [SerializeField] private int _taskType;
    [SerializeField] private Transform _interactableDirection;
    [SerializeField] private ComputerController _computerController;
    [SerializeField] private WindowController _windowController;
    [SerializeField] private DrinkMachineController _drinkMachineController;
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
            case Tasks.Expendedora:
                _drinkMachineController.GiveSoda();
                    break;
        }
    }
    public Transform GetInteractableDir()
    {
        return _interactableDirection;
    }
}
