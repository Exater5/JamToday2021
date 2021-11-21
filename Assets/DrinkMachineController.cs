using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkMachineController : MonoBehaviour
{
    [SerializeField] private GameObject _sodaPrefab;
    [SerializeField] private Transform _creationPoint;
    [SerializeField] private PickThrowZone _pickThrowZone;
    public void GiveSoda()
    {
        if (_pickThrowZone.CheckCurrentObject() == null)
        {
            _pickThrowZone.SetCurrentObject(Instantiate(_sodaPrefab, _creationPoint.position, Quaternion.identity), 1);
        }
    }
}
