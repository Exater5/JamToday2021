using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneController : MonoBehaviour
{
    [SerializeField] private Material _offMat, _onMat;
    [SerializeField] private MeshRenderer _meshRenderer;
    bool _entringCall;


    public void CallEntry()
    {
        _entringCall = true; 
        _meshRenderer.material = _onMat;
    }

    public void TakePhone()
    {
        if (_entringCall)
        {
            _meshRenderer.material = _offMat;
        }
    }
}
