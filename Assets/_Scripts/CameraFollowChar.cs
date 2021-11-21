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
        Vector3 targetRot = new Vector3(_convertedRotation.x, _convertedRotation.y - (diff * 2f), _convertedRotation.z);
        transform.rotation = Quaternion.Euler(targetRot);
    }

    public void ShakeCamera(int iterations, float strenght)
    {
        StartCoroutine(MoveRandomVertical(iterations, strenght));
    }

    IEnumerator MoveRandomVertical(int iterations, float strenght)
    {
        int iterationsCount = iterations;
        Vector3 startPos = transform.localPosition;
        float randomV = Random.Range(-0.05f, 0.05f);
        float duration = 0.05f / strenght;

        for(float i = 0; i<duration; i+= Time.deltaTime)
        {
            transform.localPosition = Vector3.Lerp(startPos, startPos + Vector3.up * randomV, i/duration);
            yield return null;
        }
        transform.localPosition = startPos;
        if (iterationsCount > 0)
        {
            iterationsCount--;
            StartCoroutine(MoveRandomVertical(iterationsCount, strenght));
        }
    }
}
