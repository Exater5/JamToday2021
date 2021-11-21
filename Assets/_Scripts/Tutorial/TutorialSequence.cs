using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSequence : MonoBehaviour
{
    [SerializeField] private UISprite _WASD;
    [SerializeField] private UISprite _shift;
    [SerializeField] private UISprite _e;
    [SerializeField] private float _startTime;
    [SerializeField] private float _timeBeforeShift;

    private bool _showWASD = false;
    private bool _waitingForShift = false;
    private bool _waitingForE = false;

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
            _waitingForShift = true;
            StartCoroutine(ShowShift());
        }

        //if (Input.GetKeyDown(KeyCode.A)) { OnInteract(); }
    }

    public void OnInteract()
    {
        _waitingForE = true;
        StartCoroutine(ShowE());
    }

    IEnumerator ShowWASD()
    {
        yield return new WaitForSeconds(_startTime);
        _WASD.gameObject.SetActive(true);
        _WASD.StartFade(true);
        _showWASD = true;
    }

    IEnumerator ShowShift()
    {
        yield return new WaitForSeconds(_timeBeforeShift);
        _shift.gameObject.SetActive(true);
        _shift.StartFade(true);

        _WASD.gameObject.SetActive(false);

        while (_waitingForShift)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                _shift.StartFade(false);
                _waitingForShift = false;
            }

            yield return null;
        }
    }

    IEnumerator ShowE()
    {
        if (!_waitingForShift)
        {
            _e.gameObject.SetActive(true);
            _e.StartFade(true);

            while (_waitingForE)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    _e.StartFade(false);
                    _waitingForE = false;
                }

                yield return null;
            }
        }        
    }
}