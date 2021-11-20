using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSequence : MonoBehaviour
{
    [SerializeField] private UISprite _WASD;
    [SerializeField] private UISprite _shift;
    [SerializeField] private UISprite _e;
    [SerializeField] private float _startTime;
    [SerializeField] private float _timeBetween;

    private bool _showWASD = true;

    private void Start()
    {
        StartCoroutine(ShowWASD());
    }

    void Update()
    {
        if (_showWASD && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A)|| Input.GetKeyDown(KeyCode.S)|| Input.GetKeyDown(KeyCode.D)))
        {
            _WASD.StartFade(false);
            _showWASD = false;
            StartCoroutine(ShowOtherControls());
        }
    }


    IEnumerator ShowWASD()
    {
        yield return new WaitForSeconds(_startTime);
        _WASD.gameObject.SetActive(true);
        _WASD.StartFade(true);
    }

    IEnumerator ShowOtherControls()
    {
        yield return new WaitForSeconds(_timeBetween);
        _WASD.gameObject.SetActive(false);
        _e.gameObject.SetActive(true);
        _e.StartFade(true);
        yield return new WaitForSeconds(_timeBetween);
        _e.StartFade(false);
        yield return new WaitForSeconds(_timeBetween);
        _e.gameObject.SetActive(false);
        _shift.gameObject.SetActive(true);
        _shift.StartFade(true);
        yield return new WaitForSeconds(_timeBetween);
        _shift.StartFade(false);
    }
}