using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JukeboxBehaviour : MonoBehaviour
{
    [SerializeField] private Gradient _gradient;
    [SerializeField] private MeshRenderer _meshRenderer;
    private Material _newMat;
    [SerializeField] private bool _powered;


    public void SwapState()
    {
        _powered = !_powered;
        if (_powered)
        {
            StartCoroutine(ChangeColor());
            GameTaskEvents.completeConcreteTask.Invoke(new TaskClass(Tasks.Jukebox, TaskFunction.Abrir));
        }
        else
        {
            GameTaskEvents.completeConcreteTask.Invoke(new TaskClass(Tasks.Jukebox, TaskFunction.Cerrar));
        }
    }

    private IEnumerator ChangeColor()
    {
        float _time = 0;

        while (_powered)
        {
            _time += Time.deltaTime;

            if (_time > 1f)
                _time = 0;

            _meshRenderer.material.SetColor("_EmissionColor", _gradient.Evaluate(_time));
            yield return null;
        }
    }
}