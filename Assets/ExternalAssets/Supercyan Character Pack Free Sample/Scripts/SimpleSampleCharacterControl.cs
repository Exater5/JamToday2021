using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class SimpleSampleCharacterControl : MonoBehaviour
{
    [SerializeField] private float m_moveSpeed = 2; 
    [SerializeField] private Animator m_animator = null;
    [SerializeField] private Rigidbody m_rigidBody = null;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private Transform _raycastOrigin, _objectsParent;
    private float m_currentV = 0;
    private float m_currentH = 0;

    private ComputerController _computerController;
    private bool _doingAction, _overInteractable, _overPickable;
    private GameObject _pickedObject;
    private PickThrowZone _lastPickThrowZone;

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
        if(Input.GetKeyDown(KeyCode.E) && !_doingAction)
        {
            if (_overInteractable)
            {
                StartCoroutine(Interact());
            }
            else if (_overPickable)
            {
                if (_pickedObject != null)
                {
                    StartCoroutine(Throw());
                }
                else if(_lastPickThrowZone.CheckCurrentObject() != null)
                {
                    if (Vector3.Angle(transform.forward, _lastPickThrowZone.CheckCurrentObject().transform.position) < 60)
                    {
                        StartCoroutine(Pick());
                    }
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.Q) && !_doingAction)
        {
            StartCoroutine(CrWave());
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

    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.layer == 6) //Interactable
        {
            _overInteractable = true;
            if (other.transform.GetComponent<ComputerController>() != null && _computerController == null)
            {
                _computerController = other.transform.GetComponent<ComputerController>();
            }
        }
        else if (other.transform.gameObject.layer == 7) //Pickable
        {
            if (_lastPickThrowZone != other.transform.GetComponent<PickThrowZone>())
            {
                _lastPickThrowZone = other.transform.GetComponent<PickThrowZone>();
            }
            _overPickable = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        _overInteractable = false;
        _overPickable = false;
    }

    public IEnumerator Interact()
    {
        _doingAction = true;
        m_animator.SetTrigger("Pickup");
        yield return new WaitForSeconds(0.5f);
        _computerController.TurnState();
        yield return new WaitForSeconds(1f);
        _doingAction = false;
    }

    public IEnumerator Pick()
    {
        _doingAction = true;
        m_animator.SetTrigger("Pickup");
        yield return new WaitForSeconds(0.5f);
        _pickedObject = _lastPickThrowZone.PickCurrentObject();
        _pickedObject.transform.SetParent(_objectsParent);
        _pickedObject.transform.localPosition = Vector3.zero;
        yield return new WaitForSeconds(1f);
        _doingAction = false;
    }
    public IEnumerator Throw()
    {
        _doingAction = true;
        m_animator.SetTrigger("Pickup");
        yield return new WaitForSeconds(0.5f);
        _lastPickThrowZone.SetCurrentObject(_pickedObject);
        _pickedObject.transform.SetParent(null);
        _pickedObject.transform.rotation = Quaternion.identity;
        _pickedObject.transform.position = _lastPickThrowZone.GetThrowPoint().position;
        _pickedObject = null;
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
