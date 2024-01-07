using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsScript : MonoBehaviour
{
    public GameObject ButtonsUI;
    public GameObject SettingsUI;
    public GameObject pauseButton;
    public GameObject joystick;

    private int count;

    void Start()
    {
        Time.timeScale = 0f;
        pauseButton.SetActive(false);
        joystick.SetActive(false);
    }

    public void OnPlayClick()
    {
        ButtonsUI.SetActive(false);
        pauseButton.SetActive(true);
        joystick.SetActive(true);
        Time.timeScale = 1f;
    }

   public void showSettingsMenu()
    {
        if(count == 0)
        {
            SettingsUI.SetActive(true);
            count = 1;
        }
        else
        {
            SettingsUI.SetActive(false);
            count = 0;
        }
    }

    public void selectBalls()
    {
        SceneManager.LoadScene("SelectBalls");
        Time.timeScale = 1f;
    }
   
}
