using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickThrowZone : MonoBehaviour
{
    [SerializeField] Transform _throwPoint;
    [SerializeField] GameObject _currentObject;
    [SerializeField] bool _soyBarra;
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
            GameTaskEvents.completeConcreteTask.Invoke(new TaskClass(Tasks.Soda, TaskFunction.Coger));
        }
        else
        {
            GameTaskEvents.completeConcreteTask.Invoke(new TaskClass(Tasks.Movil, TaskFunction.Coger));
            FindObjectOfType<PhoneController>().TakePhone();
        }
        StartCoroutine(SetNull());
        return _currentObject;
    }
    public void SetCurrentObject(GameObject current, int objectType, bool isPlayer)
    {
        _currentObject = current;
        _objectType = objectType;
        if (isPlayer)
        {
            if (_soyBarra)
            {
                if (_objectType == 1)
                {
                    GameTaskEvents.completeConcreteTask.Invoke(new TaskClass(Tasks.Soda, TaskFunction.DejarEnBarra));
                }
                else
                {
                    GameTaskEvents.completeConcreteTask.Invoke(new TaskClass(Tasks.Movil, TaskFunction.DejarEnBarra));
                }
            }
            else
            {
                if (_objectType == 1)
                {
                    GameTaskEvents.completeConcreteTask.Invoke(new TaskClass(Tasks.Soda, TaskFunction.Dejar));
                }
                else
                {
                    GameTaskEvents.completeConcreteTask.Invoke(new TaskClass(Tasks.Movil, TaskFunction.Dejar));
                }
            }
        }
    }
    IEnumerator SetNull()
    {
        yield return new WaitForSeconds(1f);
        _currentObject = null;
    }
}
