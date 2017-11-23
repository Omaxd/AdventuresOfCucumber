using System;
using UnityEngine;
using UnityEngine.UI;

public class Achivements : MonoBehaviour
{

    public Toggle Slices;
    public Toggle Time;
    public Toggle Money;

    public GameObject CurrentSlices;
    public GameObject CurrentTime;
    public GameObject CurrentMoney;

    public GameObject Chests;
    
	// Use this for initialization
    public void SlicesAchievement()
    {
        int currentSlices = Int32.Parse(CurrentSlices.GetComponent<UnityEngine.UI.Text>().text);
        if (currentSlices > 3)
            Slices.isOn = true;
        else
            Slices.isOn = false;
    }

    public void TimeAchievement()
    {
        if (CurrentTime.GetComponent<UnityEngine.UI.Text>().text.Length < 5)
            Time.isOn = true;
        else
            Time.isOn = false;
    }

    public void MoneyAchievement()
    {
        if (Chests.GetComponent<ChestsManager>().ifOpen())
            Money.isOn = true;
        else
            Money.isOn = false;
    }

}
