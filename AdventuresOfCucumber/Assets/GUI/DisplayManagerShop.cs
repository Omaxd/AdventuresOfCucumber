using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class DisplayManagerShop : MonoBehaviour
{


    public Text Cash;
    public int Money;

    List<string> dataList;

    void Start()
    {
        CheckCash();
    }

    void Update()
    {
        CheckCash();
    }

    void Fill()
    {
        Money = PlayerPrefs.GetInt("Money");
    }

    void CheckCash()
    {
        Fill();
        Cash.text = Money.ToString();
    }
}
