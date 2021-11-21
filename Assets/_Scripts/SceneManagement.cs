using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public void StartGame()
    {
        //GameFlowEvents.LoadScene.Invoke("MainGame");
        GameFlowEvents.LoadScene.Invoke("_NOTOCAR_MainGame");
    }
    public void Exit()
    {
        Application.Quit();
    }
}