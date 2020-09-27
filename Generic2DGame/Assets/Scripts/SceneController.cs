using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[DisallowMultipleComponent]
public class SceneController : MonoBehaviour
{
    #region Editor Variables
    #endregion

    #region Private Variables
    private string p_SceneName;
    private bool p_IsPaused;
    #endregion

    #region Public Variables
    public GameObject pauseScreen;
    public string mainMenuName;
    public string HUDName;
    #endregion

    #region Initialization Methods
    private void Awake()
    {
        // Load the MainMenu and HUD scenes on start.
        AddScene(mainMenuName);
        AddScene(HUDName);
    }

    private void Start()
    {
        p_SceneName = SceneManager.GetActiveScene().name;
    }
    #endregion

    #region Main Updates
    private void Update()
    {

    }
    #endregion

    #region Scene Load and Unload
    public void AddScene(string name)
    {
        SceneManager.LoadSceneAsync(name, LoadSceneMode.Additive);
    }

    public void RemoveScene(string name)
    {
        SceneManager.UnloadSceneAsync(name);
    }
    #endregion

    #region Pause
    // This version of the Pause function does not use additive scene loading.
    public void Pause()
    {
        p_IsPaused = !p_IsPaused;
        if (p_IsPaused)
        {
            Time.timeScale = 0;
            pauseScreen.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            pauseScreen.SetActive(false);
        }
    }

    // This version of the Pause function uses additive scene loading.
    public void PauseScene(string pauseSceneName)
    {
        p_IsPaused = !p_IsPaused;
        if (p_IsPaused)
        {
            Time.timeScale = 0;
            SceneManager.LoadSceneAsync(pauseSceneName, LoadSceneMode.Additive);
        }
        else
        {
            Time.timeScale = 1;
            SceneManager.UnloadSceneAsync(pauseSceneName);
        }
    }
    #endregion
}
