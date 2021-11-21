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

    private InstructionsGenerator _instructionsGenerator;

    private bool _showWASD = false;
    private bool _waitingForShift = false;
    private bool _waitingForE = false;
    private bool _showE = false;

    private void Start()
    {
        _instructionsGenerator = FindObjectOfType<InstructionsGenerator>();
        StartCoroutine(Cr_TutorialSequence());
    }
    
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.J)) { OnInteract(); }
    }

    public void OnInteract()
    {
        _waitingForE = true;
        _showE = true;
        _instructionsGenerator.OnTutorialCompleted();
    }

    IEnumerator Cr_TutorialSequence()
    {
        yield return new WaitForSeconds(_startTime);
        _WASD.gameObject.SetActive(true);
        _WASD.StartFade(true);
        _showWASD = true;

        while (_showWASD)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
            {
                _WASD.StartFade(false);
                _showWASD = false;
                _waitingForShift = true;
            }

            yield return null;
        }        

        yield return new WaitForSeconds(_timeBeforeShift);

        if (_waitingForShift)
        {
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

        while (!_waitingForShift && !_waitingForE)
        {
            
            yield return null;
        }

        while (_waitingForE)
        {
            if (_showE)
            {
                _e.gameObject.SetActive(true);
                _e.StartFade(true);
                _showE = false;
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                _e.StartFade(false);
                _waitingForE = false;
            }

            yield return null;
        }
    }
}