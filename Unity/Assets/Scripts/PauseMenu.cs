using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    public static bool GamesIsPaused = false;

    public Button pause_btn;
    private Button button;

    public GameObject pauseMenuUI;

    void Start()
    {
        button = pause_btn.GetComponent<Button>();
    }
    
    void Update()
    {
        button.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        Pause();
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GamesIsPaused = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GamesIsPaused = true;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
