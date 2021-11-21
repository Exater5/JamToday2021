using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InstructionsGenerator : MonoBehaviour
{
    [SerializeField] private Animator _textAnimator;
    [SerializeField] private Timer _timer;

    private List<string> _tasksInfos;
    private List<float> _tasksTimes;
    private List<List<TaskClass>> _allTasks;
    private string _actualTask;
    private bool _tutCompleted;

    [SerializeField] private TextMeshProUGUI taskText, _stakedTaskTx;
    
    void Awake()
    {
        _tasksInfos = new List<string>();
        _tasksTimes = new List<float>();
        _allTasks = new List<List<TaskClass>>();
        _tasksInfos.Add("Enciende el ordenador.");
        _allTasks.Add(new List<TaskClass>() { new TaskClass(Tasks.Ordenador, TaskFunction.Abrir) });
        _tasksTimes.Add(20f);
        _tasksInfos.Add("Abre la ventana");
        _allTasks.Add(new List<TaskClass>() { new TaskClass(Tasks.Ventana, TaskFunction.Abrir)});
        _tasksTimes.Add(20f);
        _tasksInfos.Add("Lleva un refresco a la barra del bar.");
        _allTasks.Add(new List<TaskClass>() { new TaskClass(Tasks.Expendedora, TaskFunction.Usar), new TaskClass(Tasks.Soda, TaskFunction.Coger), new TaskClass(Tasks.Soda, TaskFunction.DejarEnBarra) });
        _tasksTimes.Add(30f);
        _tasksInfos.Add("Coge la llamada del móvil, enciende la jukebox y usa el portátil.");
        _tasksInfos.Add("Enciende las luces, cierra la puerta y saca una foto.");
        _tasksInfos.Add("Apaga el ordenador, coge el móvil y no cierres la ventana.");
        _tasksInfos.Add("Apaga las luces, coge un refresco, déjalo en la mesa de la impresora y abre la puerta.");
        _tasksInfos.Add("Haz una foto, deja las luces apagadas, cierra la ventana y no cojas el móvil.");
        _tasksInfos.Add("Imprime un documento, enciende las luces, apaga el ordenador y abre la puerta.");
        _tasksInfos.Add("Coge otro refresco y déjalo junto al pc, apaga el portátil, no dejes que la canción siga sonando y saca otra foto.");
        _tasksInfos.Add("Enciende el ordenador,  apaga el ordenador y vuelve a encenderlo mientras no estás en silencio.");
        _tasksInfos.Add("Abre la ventana, coge el móvil, imprime otro documento y enciende el portátil.");
        _tasksInfos.Add("Cierra la puerta, apaga las luces, coge un refresco y déjalo junto al móvil, imprime otro documento más y no no apagues el ordenador.");
        _tasksInfos.Add("Cierra la ventana, no no no dejes encendida la jukebox, no imprimas otro documento, usa el ordenador y lleva un refresco a tu compañero de vagón.");
        _tasksInfos.Add("Saca dos fotos, coge la llamada, saca otra foto más, apaga el portátil, enciende las luces y haz lo contrario en la siguiente tarea.");
        _tasksInfos.Add("No no no imprimas nada, deja cerrada la ventana y estate en completo silencio.");
    }

    private void Start()
    {
        StartCoroutine(CrTaskShow());
        _tutCompleted = true;
    }

    public void ShowTask()
    {
        _actualTask = _tasksInfos[GameController.currentTaskIndex];
        taskText.text = _actualTask;
        _textAnimator.Play("ShowTask");
    }

    public void OnTaskDisabled()
    {
        _stakedTaskTx.text = _actualTask = _tasksInfos[GameController.currentTaskIndex];
    }

    public List<List<TaskClass>> GetToDoTasksList()
    {
        return _allTasks;
    }

    IEnumerator CrTaskShow()
    {
        while (!_tutCompleted)
        {
            yield return null;
        }
        yield return new WaitForSeconds(2f);
        ShowTask();
        yield return new WaitForSeconds(1.5f);
        _timer.StartTimer(_tasksTimes[GameController.currentTaskIndex]);
    }

    public void OnFailTask()
    {
        _timer.OnFailTask();
    }

    public void OnTutorialCompleted()
    {
        _tutCompleted = true;
    }

    public void OnNextTask()
    {
        StartCoroutine(CrTaskShow());
    }
}