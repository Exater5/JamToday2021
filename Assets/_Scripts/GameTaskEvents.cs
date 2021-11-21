using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum Tasks {Ordenador, Ventana, Expendedora, Soda, Movil, Jukebox, Impresora}
public enum TaskFunction {Abrir, Cerrar, DejarEnBarra}
public static class GameTaskEvents
{
    public static SimpleTaskEvent completeTask = new SimpleTaskEvent();
    public static ConcreteTaskEvent completeConcreteTask = new ConcreteTaskEvent();
    public class SimpleTaskEvent : UnityEvent<Tasks> { };
    public class ConcreteTaskEvent : UnityEvent<TaskClass> { };
}
