using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TaskClass
{
    public Tasks task;
    public TaskFunction taskFunction;

    public TaskClass(Tasks tT, TaskFunction tF)
    {
        task = tT;
        taskFunction = tF;
    }
}
