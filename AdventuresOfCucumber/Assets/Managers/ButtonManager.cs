using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    List<string> dataList;

    public int Money, Slices;

    public Text message;
    public Text SlicePrice;

    public GameObject Panel;
    public GameObject AchievementManager;

    private Achivements achievements;

    public void NewGameButton(string GameLevel)
    {
        SceneManager.LoadScene(GameLevel);
    }

    public void ExitGameButton()
    {
        Application.Quit();
    }

    public void HowToPlayButton()
    {
        SceneManager.LoadScene("HowToPlay");
    }

    public void ShopButton()
    {
        SceneManager.LoadScene("Shop");
    }

    public void BuyingButton()
    {
        FillMoney();
        FillSlices();
        Debug.Log(Money);
        if (Money < 20)
        {
            message.text = "";
            message.enabled = true;
            message.text = "Za mało monet!";
            Invoke("DisableText", 2);
    }
        else
        {
            Money -= 20;
            SaveActualMoneyBillance();
            Slices += 1;
            SaveActualSlicesBillance();
        }
    }

    void DisableText()
    {
        message.enabled = false;
    }

    void SaveActualMoneyBillance()
    {
        PlayerPrefs.SetInt("Money", Money);
        PlayerPrefs.Save();
    }

    void SaveActualSlicesBillance()
    {
        PlayerPrefs.SetInt("CurrentSlices", Slices);
        PlayerPrefs.Save();
    }
    void FillMoney()
    {
        Money= PlayerPrefs.GetInt("Money");
    }

    void FillSlices()
    {
        Slices = PlayerPrefs.GetInt("CurrentSlices");
    }

    public void AchievementsButton()
    {
        achievements = AchievementManager.GetComponent<Achivements>();
        achievements.SlicesAchievement();
        achievements.TimeAchievement();
        achievements.MoneyAchievement();
        if (Panel.active)
        {
            Panel.SetActive(false);
        }
        else
        {          
            Panel.SetActive(true);
        }
    }
}
