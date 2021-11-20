using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum Tasks {Ordenador, Ventana, Movil, Impresora, Jukebox, Expendedora}
public static class GameTaskEvents
{
    public static SimpleTaskEvent completeTask = new SimpleTaskEvent();
    public class SimpleTaskEvent : UnityEvent<Tasks> { };
}
