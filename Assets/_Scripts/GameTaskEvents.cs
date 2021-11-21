using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum Tasks {Ordenador, Ventana, Expendedora, Soda, Movil, Jukebox, Impresora, Router, Portatil, Camara}
public enum TaskFunction {Abrir, Cerrar, DejarEnBarra, Coger, Dejar, Usar}
public static class GameTaskEvents
{
    public static ConcreteTaskEvent completeConcreteTask = new ConcreteTaskEvent();
    public class ConcreteTaskEvent : UnityEvent<TaskClass> { };
}
