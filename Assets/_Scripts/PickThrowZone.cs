using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickThrowZone : MonoBehaviour
{
    [SerializeField] Transform _throwPoint;
    [SerializeField] GameObject _currentObject;
    int _objectType; //0 soda, 1 movil

    public Transform GetThrowPoint()
    {
        return _throwPoint;
    }

    public GameObject CheckCurrentObject()
    {
        return _currentObject;
    }

    public int GetObjectType()
    {
        return _objectType;
    }

    public GameObject PickCurrentObject()
    {
        if (_objectType == 1)
        {
            GameTaskEvents.completeTask.Invoke(Tasks.Expendedora);
        }
        else
        {
            GameTaskEvents.completeTask.Invoke(Tasks.Movil);
        }
        StartCoroutine(SetNull());
        return _currentObject;
    }
    public void SetCurrentObject(GameObject current, int objectType)
    {
        _currentObject = current;
        _objectType = objectType;
    }
    IEnumerator SetNull()
    {
        yield return new WaitForSeconds(1f);
        _currentObject = null;
    }
}
