using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Select_ball : MonoBehaviour
{

    private GameObject[] characterList;
    public GameObject SettingsUI;
    private int index;
    private int level;
    private int count;


    private void Start()
    {
        level = PlayerPrefs.GetInt("cur_lvl");
        index = PlayerPrefs.GetInt("Ball_Selected");

        characterList = new GameObject[transform.childCount];
        for(int i = 0; i < transform.childCount; i++)
        {
            characterList[i] = transform.GetChild(i).gameObject;
        }
        foreach(GameObject go in characterList)
        {
            go.SetActive(false);
        }
        if (characterList[index])
        {
            characterList[index].SetActive(true);
        }

    }

    public void prev()
    {
        characterList[index].SetActive(false);
        index--;
        if (index < 0)
            index = characterList.Length - 1;
        characterList[index].SetActive(true);
    }
    public void next()
    {
        characterList[index].SetActive(false);
        index++;
        if (index == characterList.Length)
            index = 0;
        characterList[index].SetActive(true);
    }

    public void confirm()
    {
        PlayerPrefs.SetInt("Ball_Selected", index);
        if (level == 0)
        {
            SceneManager.LoadScene(1);
            PlayerPrefs.SetInt("cur_lvl", 1);
        }
        else
        {
            SceneManager.LoadScene(level);
        }  
    }
   
    public void showSettingsMenu()
    {
        if (count == 0)
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


}
