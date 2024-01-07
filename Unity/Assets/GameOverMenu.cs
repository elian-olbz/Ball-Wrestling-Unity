using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    public Ball_Health player_health;
    public Ball_Health enemy_health;
    public GameObject gameOverMenuUI;
    public GameObject completeMenuUI;
    public GameObject joystick;
    private int level;
    private bool isActive = false;


    void Start()
    {
        level = PlayerPrefs.GetInt("cur_lvl");
    }
    void FixedUpdate()
    {
        if (player_health.getHealth() == 0f && isActive == false)
        {
            gameOverMenuUI.SetActive(true);
            joystick.SetActive(false);
            StartCoroutine(Pause());
        }
        else if(enemy_health.getHealth() == 0f &&isActive == false)
        {
            completeMenuUI.SetActive(true);
            joystick.SetActive(false);
            StartCoroutine(Pause());
            isActive = true;
        }
    }
    public void Continue()
    {
        PlayerPrefs.SetInt("cur_lvl", level + 1);
        //need to add limit to increment
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;
        completeMenuUI.SetActive(false);
        player_health.resetHealth();
        enemy_health.resetHealth();
        isActive = false;
        //Debug.Log(level);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
        gameOverMenuUI.SetActive(false);
        player_health.resetHealth();
        enemy_health.resetHealth();
        isActive = false;
    }
    IEnumerator Pause()
    {
        Time.timeScale = 0.5f;
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 0.4f;
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 0f;
    }
   
}
