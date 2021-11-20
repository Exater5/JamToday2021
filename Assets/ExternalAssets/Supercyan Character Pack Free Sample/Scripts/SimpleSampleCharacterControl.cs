using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class SimpleSampleCharacterControl : MonoBehaviour
{
    [SerializeField] private float m_moveSpeed = 2; 
    [SerializeField] private Animator m_animator = null;
    [SerializeField] private Rigidbody m_rigidBody = null;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private Transform _raycastOrigin;
    private float m_currentV = 0;
    private float m_currentH = 0;

    private ComputerController _computerController;
    private bool _doingAction, _overInteractable;

    private readonly float m_interpolation = 10;
    private readonly float m_walkScale = 0.33f;

    private Vector3 m_currentDirection = Vector3.zero;
    private Camera _mainCamera;


    private void Awake()
    {
        _mainCamera = Camera.main;
        if (!m_animator) { gameObject.GetComponent<Animator>(); }
        if (!m_rigidBody) { gameObject.GetComponent<Animator>(); }
    }

    private void Start()
    {
        StartCoroutine(CrWave());
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && !_doingAction && _overInteractable)
        {
            StartCoroutine(CrPickUp());
        }
        else if (Input.GetKeyDown(KeyCode.Q) && !_doingAction)
        {
            StartCoroutine(CrWave());
        }
        RaycastHit hit;

        if (_raycastOrigin != null)
        {
            if (Physics.Raycast(_raycastOrigin.position, transform.TransformDirection(Vector3.forward), out hit, 1f, _layerMask))
            {
                _overInteractable = true;
                if (hit.transform.GetComponent<ComputerController>() != null && _computerController == null)
                {
                    _computerController = hit.transform.GetComponent<ComputerController>();
                }
            }
            else
            {
                _overInteractable = false;
            }
        }        
    }

    private void FixedUpdate()
    {
        DirectUpdate();
    }
    private void DirectUpdate()
    {
        if (!_doingAction)
        {
            float v = Input.GetAxis("Vertical");
            float h = Input.GetAxis("Horizontal");
            Transform camera = _mainCamera.transform;
            if (!Input.GetKey(KeyCode.LeftShift))
            {
                v *= m_walkScale;
                h *= m_walkScale;
            }

            m_currentV = Mathf.Lerp(m_currentV, v, Time.deltaTime * m_interpolation);
            m_currentH = Mathf.Lerp(m_currentH, h, Time.deltaTime * m_interpolation);

            Vector3 direction = camera.forward * m_currentV + camera.right * m_currentH;

            float directionLength = direction.magnitude;
            direction.y = 0;
            direction = direction.normalized * directionLength;

            if (direction != Vector3.zero)
            {
                m_currentDirection = Vector3.Slerp(m_currentDirection, direction, Time.deltaTime * m_interpolation);

                transform.rotation = Quaternion.LookRotation(m_currentDirection);
                transform.position += m_currentDirection * m_moveSpeed * Time.deltaTime;

                m_animator.SetFloat("MoveSpeed", direction.magnitude);
            }
        }     
    }

    public IEnumerator CrPickUp()
    {
        _doingAction = true;
        m_animator.SetTrigger("Pickup");
        yield return new WaitForSeconds(0.5f);
        _computerController.TurnState();
        yield return new WaitForSeconds(1f);
        _doingAction = false;
    }
    public IEnumerator CrWave()
    {
        _doingAction = true;
        m_animator.SetTrigger("Wave");
        yield return new WaitForSeconds(2f);
        _doingAction = false;
    }
}
