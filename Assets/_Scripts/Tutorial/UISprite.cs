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
        StartCoroutine(Fade(appear));
    }

    private IEnumerator Fade(bool appear)
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        for (float i = 0; i < _timeToFade; i += Time.deltaTime)
        {
            if (!appear)
            {
                spriteRenderer.color = Color.Lerp(Color.white, _transparent, i / _timeToFade);
                yield return null;
            }
            else
            {
                spriteRenderer.color = Color.Lerp(_transparent, Color.white, i / _timeToFade);
                yield return null;
            }
        }
    }
}