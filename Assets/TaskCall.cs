using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskCall : MonoBehaviour
{
    [SerializeField] InstructionsGenerator instructionsGenerator;

    public void OnCallBack()
    {
        instructionsGenerator.OnTaskDisabled();
    }
}
