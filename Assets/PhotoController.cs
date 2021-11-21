using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoController : MonoBehaviour
{
    [SerializeField] Animator _animator;
    public void TakePhoto()
    {
        _animator.SetTrigger("Photo");
        GameTaskEvents.completeConcreteTask.Invoke(new TaskClass(Tasks.Camara, TaskFunction.Abrir));
    }
}
