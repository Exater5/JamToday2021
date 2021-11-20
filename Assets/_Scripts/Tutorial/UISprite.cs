using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISprite : MonoBehaviour
{
    [SerializeField] private float _timeToFade;
    [SerializeField] private Color _transparent;
    [SerializeField] private bool _follow;
    [SerializeField] private Transform _objectToFollow;
    [SerializeField] private Vector3 _offset;
    private void Start()
    {
        transform.LookAt(Camera.main.transform);
        transform.Rotate(Vector3.up * 180);
    }

    void LateUpdate () 
    {
        if (_follow)
            transform.position = _objectToFollow.position - _offset;
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
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        for (float i = 0; i < _timeToFade; i += Time.deltaTime)
        {
            spriteRenderer.color = Color.Lerp(originC, targetC, i / _timeToFade);
            yield return null;
        }
        spriteRenderer.color = targetC;
    }
}