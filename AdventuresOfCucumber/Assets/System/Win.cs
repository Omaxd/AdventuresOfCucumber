using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Win : MonoBehaviour {

    public GameObject heroInfo;
    public GameObject GUImanager;
    public AudioSource win;

    public Toggle Slices;
    public Toggle Time;
    public Toggle Money;

    private string _slices;
    private string _time;
    private string _money;

    void OnCollisionEnter(Collision other)
    {
        win.Play();
        CheckingToggles();
        GameObject.Find("HeroInfo").GetComponent<HeroInfo>().Save();
        string money = heroInfo.GetComponent<HeroInfo>().Money.ToString();
        string hp = heroInfo.GetComponent<HeroInfo>().CurrentHp.ToString();
        string slices = heroInfo.GetComponent<HeroInfo>().CurrentSlices.ToString();
        string time = GUImanager.GetComponent<DisplayManager>().time.ToString();
        /*using (System.IO.StreamWriter file =
            new System.IO.StreamWriter("Assets/File/Record.txt", true))
            {
                file.WriteLine("Time: "+time+" -- Money: "+money+" -- HP: "+hp+" -- Slices: "+slices+" -- Slices achievement: "+_slices 
                    +" -- Time achievement: "+_time+" -- Money achievement: "+_money);
            }*/
        SceneManager.LoadScene("Menu");

    }

    void CheckingToggles()
    {
        if (Slices.isOn)
            _slices = "Yes";
        else
            _slices = "No";
        if (Money.isOn)
            _money = "Yes";
        else
            _money = "No";
        if (Time.isOn)
            _time = "Yes";
        else
            _time = "No";
    }

}
