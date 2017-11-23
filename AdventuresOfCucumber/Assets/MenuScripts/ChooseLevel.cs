using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseLevel : MonoBehaviour {

    public int maxNumberOfLevel;
    int actualChoose;


    void Start() {
        actualChoose = 1;
    }

    void Update() {
        SelectLevel();
    }


    void SelectLevel()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) SelectNextLevel();
        if (Input.GetKeyDown(KeyCode.DownArrow)) SelectPreviousLevel();
        if (Input.GetKeyDown(KeyCode.KeypadEnter)) ExecuteSelectedLevel();

    }
    void SelectNextLevel()
    {
        if (actualChoose == maxNumberOfLevel) actualChoose = 1;
        else actualChoose++;
    }
    void SelectPreviousLevel()
    {
        if (actualChoose == 1) actualChoose = maxNumberOfLevel;
        else actualChoose--;
    }
    void ExecuteSelectedLevel()
    {
        string levelName = "Level" + actualChoose;
        SceneManager.LoadScene(levelName);
    }

}
