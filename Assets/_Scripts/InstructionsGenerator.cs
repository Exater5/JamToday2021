using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InstructionsGenerator : MonoBehaviour
{
    [SerializeField] private Animator _textAnimator;

    private List<string> tasks;
    private int currentTask = 0;

    private string actualTask;

    [SerializeField] private TextMeshProUGUI taskText;
    
    void Awake()
    {
        tasks = new List<string>();

        tasks.Add("Enciende el ordenador.");
        tasks.Add("Abre la ventana y bebe un refresco.");
        tasks.Add("Coge la llamada del m�vil, enciende la jukebox y usa el port�til.");
        tasks.Add("Enciende las luces, cierra la puerta y saca una foto.");
        tasks.Add("Apaga el ordenador, coge el m�vil y no cierres la ventana.");
        tasks.Add("Apaga las luces, coge un refresco, d�jalo en la barra y abre la puerta.");
        tasks.Add("Haz una foto, deja las luces apagadas, cierra la ventana y no cojas el m�vil.");
        tasks.Add("Imprime un documento, enciende las luces, apaga el ordenador y abre la puerta.");
        tasks.Add("Coge otro refresco y d�jalo junto al pc, apaga el port�til, no dejes que la canci�n siga sonando y saca otra foto.");
        tasks.Add("Enciende el ordenador,  apaga el ordenador y vuelve a encenderlo mientras no est�s en silencio.");
        tasks.Add("Abre la ventana, coge el m�vil, imprime otro documento y enciende el port�til.");
        tasks.Add("Cierra la puerta, apaga las luces, coge un refresco y d�jalo junto al m�vil, imprime otro documento m�s y no no apagues el ordenador.");
        tasks.Add("Cierra la ventana, no no no dejes encendida la jukebox, no imprimas otro documento, usa el ordenador y b�bete un refresco.");
        tasks.Add("Saca dos fotos, coge la llamada, saca otra foto m�s, apaga el port�til, enciende las luces y haz lo contrario en la siguiente tarea.");
        tasks.Add("No no no imprimas nada, deja cerrada la ventana y estate en silencio.");
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
}