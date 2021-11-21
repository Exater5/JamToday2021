using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundParallax : MonoBehaviour
{
    [SerializeField] private float _trainSpeed;
    [SerializeField] private float _timeToFade;
    [SerializeField] private Material _matBack, _matBackMid, _matFrontMid, _matFront;
    [SerializeField] private bool _changeColor;
    [SerializeField] private Color _targetC;

    private void Start()
    {
        _matBack.color = Color.white;
        _matBackMid.color = Color.white; 
        _matFrontMid.color = Color.white;
        _matFront.color = Color.white;
    }

    void Update()
    {
        _matBack.mainTextureOffset += Vector2.right * _trainSpeed * .1f * Time.deltaTime;
        _matBackMid.mainTextureOffset += Vector2.right * _trainSpeed * .2f * Time.deltaTime;
        _matFrontMid.mainTextureOffset += Vector2.right * _trainSpeed * .3f * Time.deltaTime;
        _matFront.mainTextureOffset += Vector2.right * _trainSpeed * .4f * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.L)) { StartCoroutine(ChangeBackground()); }
    }

    IEnumerator ChangeBackground()
    {
        if (_changeColor)
        {
            for (float i = 0; i < _timeToFade; i += Time.deltaTime)
            {
                _matBack.color = Color.Lerp(Color.white, _targetC, i / _timeToFade);
                _matBackMid.color = Color.Lerp(Color.white, _targetC, i / _timeToFade);
                _matFrontMid.color = Color.Lerp(Color.white, _targetC, i / _timeToFade);
                _matFront.color = Color.Lerp(Color.white, _targetC, i / _timeToFade);
                yield return null;
            }

            _matBack.color = _targetC;
            _matBackMid.color = _targetC;
            _matFrontMid.color = _targetC;
            _matFront.color = _targetC;
        }
    }
}