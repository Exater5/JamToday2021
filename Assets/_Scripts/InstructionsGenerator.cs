using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InstructionsGenerator : MonoBehaviour
{
    [SerializeField] private Animator _textAnimator;

    private List<string> tasks;
    private List<List<Tasks>> taskTypes;
    private int currentTask = 0;
    private string actualTask;

    [SerializeField] private TextMeshProUGUI taskText, _stakedTaskTx;
    
    void Awake()
    {
        tasks = new List<string>();
        taskTypes = new List<List<Tasks>>();
        tasks.Add("Enciende el ordenador.");
        taskTypes.Add(new List<Tasks>() { Tasks.Ordenador });
        tasks.Add("Abre la ventana y lleva un refresco a la barra del bar.");
        tasks.Add("Coge la llamada del móvil, enciende la jukebox y usa el portátil.");
        tasks.Add("Enciende las luces, cierra la puerta y saca una foto.");
        tasks.Add("Apaga el ordenador, coge el móvil y no cierres la ventana.");
        tasks.Add("Apaga las luces, coge un refresco, déjalo en la mesa de la impresora y abre la puerta.");
        tasks.Add("Haz una foto, deja las luces apagadas, cierra la ventana y no cojas el móvil.");
        tasks.Add("Imprime un documento, enciende las luces, apaga el ordenador y abre la puerta.");
        tasks.Add("Coge otro refresco y déjalo junto al pc, apaga el portátil, no dejes que la canción siga sonando y saca otra foto.");
        tasks.Add("Enciende el ordenador,  apaga el ordenador y vuelve a encenderlo mientras no estás en silencio.");
        tasks.Add("Abre la ventana, coge el móvil, imprime otro documento y enciende el portátil.");
        tasks.Add("Cierra la puerta, apaga las luces, coge un refresco y déjalo junto al móvil, imprime otro documento más y no no apagues el ordenador.");
        tasks.Add("Cierra la ventana, no no no dejes encendida la jukebox, no imprimas otro documento, usa el ordenador y lleva un refresco a tu compañero de vagón.");
        tasks.Add("Saca dos fotos, coge la llamada, saca otra foto más, apaga el portátil, enciende las luces y haz lo contrario en la siguiente tarea.");
        tasks.Add("No no no imprimas nada, deja cerrada la ventana y estate en completo silencio.");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) { ShowTask(); }
    }

    public void ShowTask()
    {
        actualTask = tasks[currentTask];
        taskText.text = actualTask;
        _textAnimator.Play("ShowTask");
        currentTask++;
    }

    public void OnTaskDisabled()
    {
        _stakedTaskTx.text = actualTask = tasks[currentTask -1];
    }

    public List<List<Tasks>> GetToDoTasksList()
    {
        return taskTypes;
    }
}