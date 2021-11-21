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
    private List<List<Tasks>> _taskTypes;
    private int _currentTask = 0;
    private string _actualTask;
    private bool _tutCompleted;

    [SerializeField] private TextMeshProUGUI taskText, _stakedTaskTx;
    
    void Awake()
    {
        _tasksInfos = new List<string>();
        _tasksTimes = new List<float>();
        _taskTypes = new List<List<Tasks>>();
        _tasksInfos.Add("Enciende el ordenador.");
        _taskTypes.Add(new List<Tasks>() { Tasks.Ordenador });
        _tasksTimes.Add(20f);
        _tasksInfos.Add("Abre la ventana y lleva un refresco a la barra del bar.");
        _tasksInfos.Add("Coge la llamada del m�vil, enciende la jukebox y usa el port�til.");
        _tasksInfos.Add("Enciende las luces, cierra la puerta y saca una foto.");
        _tasksInfos.Add("Apaga el ordenador, coge el m�vil y no cierres la ventana.");
        _tasksInfos.Add("Apaga las luces, coge un refresco, d�jalo en la mesa de la impresora y abre la puerta.");
        _tasksInfos.Add("Haz una foto, deja las luces apagadas, cierra la ventana y no cojas el m�vil.");
        _tasksInfos.Add("Imprime un documento, enciende las luces, apaga el ordenador y abre la puerta.");
        _tasksInfos.Add("Coge otro refresco y d�jalo junto al pc, apaga el port�til, no dejes que la canci�n siga sonando y saca otra foto.");
        _tasksInfos.Add("Enciende el ordenador,  apaga el ordenador y vuelve a encenderlo mientras no est�s en silencio.");
        _tasksInfos.Add("Abre la ventana, coge el m�vil, imprime otro documento y enciende el port�til.");
        _tasksInfos.Add("Cierra la puerta, apaga las luces, coge un refresco y d�jalo junto al m�vil, imprime otro documento m�s y no no apagues el ordenador.");
        _tasksInfos.Add("Cierra la ventana, no no no dejes encendida la jukebox, no imprimas otro documento, usa el ordenador y lleva un refresco a tu compa�ero de vag�n.");
        _tasksInfos.Add("Saca dos fotos, coge la llamada, saca otra foto m�s, apaga el port�til, enciende las luces y haz lo contrario en la siguiente tarea.");
        _tasksInfos.Add("No no no imprimas nada, deja cerrada la ventana y estate en completo silencio.");
    }

    private void Start()
    {
        StartCoroutine(CrTaskShow());
        _tutCompleted = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) { ShowTask(); }
    }

    public void ShowTask()
    {
        _actualTask = _tasksInfos[_currentTask];
        taskText.text = _actualTask;
        _textAnimator.Play("ShowTask");
        _currentTask++;
    }

    public void OnTaskDisabled()
    {
        _stakedTaskTx.text = _actualTask = _tasksInfos[_currentTask -1];
    }

    public List<List<Tasks>> GetToDoTasksList()
    {
        return _taskTypes;
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
        _timer.StartTimer(_tasksTimes[_currentTask-1]);
    }

    public void OnFailTask()
    {
        _timer.OnFailTask();
    }

    public void OnTutorialCompleted()
    {
        _tutCompleted = true;
    }
}