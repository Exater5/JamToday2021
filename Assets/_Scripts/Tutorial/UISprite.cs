using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UISprite : MonoBehaviour
{
    [SerializeField] private float _timeToFade;
    [SerializeField] private Color _transparent;
    [SerializeField] private bool _follow;
    [SerializeField] private Transform _objectToFollow;
    [SerializeField] private Vector3 _offset;
    private TextMeshProUGUI _image;
    private void Start()
    {
        _image = GetComponent<TextMeshProUGUI>();
    }

    void LateUpdate () 
    {
        if (_follow)
            transform.position = RectTransformUtility.WorldToScreenPoint(Camera.main, _objectToFollow.position + _offset);
    }

    public void StartFade(bool appear)
    {
        if (appear)
        {
            StartCoroutine(Fade(_transparent, Color.white));
        }
        else
        {
            StartCoroutine(Fade(Color.white, _transparent));
        }
    }

    private IEnumerator Fade(Color originC, Color targetC)
    {
        for (float i = 0; i < _timeToFade; i += Time.deltaTime)
        {
            _image.color = Color.Lerp(originC, targetC, i / _timeToFade);
            yield return null;
        }

        _image.color = targetC;
    }
}