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
    [SerializeField] private RouterController _routerController;
    [SerializeField] private LaptopController _laptopController;
    [SerializeField] private PhotoController _photoController;
    [SerializeField] private JukeboxBehaviour _jukeboxBehaviour;
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
            case Tasks.Router:
                _routerController.SwapState();
                break;
            case Tasks.Portatil:
                _laptopController.TurnState();
                break;
            case Tasks.Camara:
                _photoController.TakePhoto();
                break;
            case Tasks.Jukebox:
                _jukeboxBehaviour.SwapState();
                break;
        }
    }
    public Transform GetInteractableDir()
    {
        return _interactableDirection;
    }
}
