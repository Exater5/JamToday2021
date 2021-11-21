using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JukeboxBehaviour : MonoBehaviour
{
    [SerializeField] private Gradient _gradient;
    [SerializeField] private MeshRenderer _meshRenderer;
    private Material _newMat;

    [SerializeField] private bool _powered;

    private void Start()
    {
        _meshRenderer.material = _newMat;
    }

    public void PowerOn()
    {
        _powered = true;
        StartCoroutine(ChangeColor());
    }

    private IEnumerator ChangeColor()
    {
        float _time = 0;

        while (_powered)
        {
            _time += Time.deltaTime;

            if (_time > 1f)
                _time = 0;

            _meshRenderer.material.color = _gradient.Evaluate(_time);
            yield return null;
        }
    }
}