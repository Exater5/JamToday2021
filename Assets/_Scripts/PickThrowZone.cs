using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickThrowZone : MonoBehaviour
{
    [SerializeField] Transform _throwPoint;
    [SerializeField] GameObject _currentObject;


    public Transform GetThrowPoint()
    {
        return _throwPoint;
    }

    public GameObject CheckCurrentObject()
    {
        return _currentObject;
    }

    public GameObject PickCurrentObject()
    {
        StartCoroutine(SetNull());
        return _currentObject;
    }
    public void SetCurrentObject(GameObject current)
    {
        _currentObject = current;
    }
    IEnumerator SetNull()
    {
        yield return new WaitForSeconds(1f);
        _currentObject = null;
    }
}
