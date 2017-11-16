using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class HeroInfo : MonoBehaviour
{
    public int MaxHp;
    public int CurrentHp;
    public int MaxSlices;
    public int CurrentSlices;
    public int MoveSpeed;
    public int MaxSpeed;
    public int Money;

    void Start()
    {
        Load();
    }

    void Load()
    {
        MoveSpeed = 20;
        MaxSpeed = 35;
        SetMaxHP();
        SetCurrentHp();
        SetMaxSlices();
        //CurrentSlices= 10;
        SetCurrentSlices();
        SetMoney();
        PlayerPrefs.Save();

    }
    public void Save() //Current slices = MaxSlices -> No to pause
    {
        PlayerPrefs.SetInt("MaxHp", MaxHp);
        PlayerPrefs.SetInt("MaxSlices", MaxSlices);
        PlayerPrefs.SetInt("Money", Money);
        PlayerPrefs.SetInt("CurrentSlices", MaxSlices);
        PlayerPrefs.Save();
    }

    void SetMaxHP()
    {
        if (PlayerPrefs.HasKey("MaxHp")) MaxHp = PlayerPrefs.GetInt("MaxHp");
        else
        {
            MaxHp = 5;
            PlayerPrefs.SetInt("MaxHp", MaxHp);
        }
    }
    void SetMaxSlices()
    {
        if (PlayerPrefs.HasKey("MaxSlices")) MaxSlices = PlayerPrefs.GetInt("MaxSlices");
        else
        {
            MaxSlices = 10;
            PlayerPrefs.SetInt("MaxSlices", MaxSlices);
        }
    }
    void SetMoney()
    {
        if (PlayerPrefs.HasKey("Money")) Money = PlayerPrefs.GetInt("Money");
        else
        {
            Money = 0;
            PlayerPrefs.SetInt("Money", Money);
        }
    }
    void SetCurrentSlices()
    {
        if (PlayerPrefs.HasKey("CurrentSlices")) CurrentSlices = PlayerPrefs.GetInt("CurrentSlices");
        else
        {
            CurrentSlices = MaxSlices;
            PlayerPrefs.SetInt("CurrentSlices", CurrentSlices);
        }
    }
    void SetCurrentHp() //No playerPrefs
    {
        CurrentHp = MaxHp;
    }
}
