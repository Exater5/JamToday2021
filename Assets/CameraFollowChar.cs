using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowChar : MonoBehaviour
{
    [SerializeField] Transform _player;
    private Vector3 _startPlayerPos, _convertedRotation;
    private Quaternion _startRotation;

    private void Start()
    {
        _startRotation = transform.rotation;
        _convertedRotation = _startRotation.eulerAngles;
        _startPlayerPos = _player.position;
    }
    // Update is called once per frame
    void Update()
    {
        float diff = _player.position.z - _startPlayerPos.z;
        Vector3 targetRot = new Vector3(_convertedRotation.x, _convertedRotation.y + diff, _convertedRotation.z);
        transform.rotation = Quaternion.Euler(targetRot);
    }
}
