using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotate : MonoBehaviour
{
    [SerializeField] private float _degreesPerSec;

    void Update()
    {
        transform.Rotate(0,_degreesPerSec * Time.deltaTime, 0);
    }
}
