using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadGameLevel1()
    {
        SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
    }

    public void LoadScoreScreen()
    {
        SceneManager.LoadSceneAsync(2, LoadSceneMode.Single);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
