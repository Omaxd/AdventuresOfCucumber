using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DisplayManager : MonoBehaviour {

    public GameObject heroInfo;
    public RawImage sliceIcon;
    public Text currAmmo;
    public Text maxAmmo;
    public Text cash;
    public Text timer;
    public Text timerS;
    public RawImage life1;
    public RawImage life2;
    public RawImage life3;
    public RawImage life4;
    public RawImage life5;

    //Dodaj do rekordów
    public float time;
    
    void Start()
    {
        time = 0;
    }

	void Update () {
        CheckStats();       
	}

    void CheckStats()
    {
        currAmmo.text = (heroInfo.GetComponent<HeroInfo>().CurrentSlices).ToString();
        maxAmmo.text = (heroInfo.GetComponent<HeroInfo>().MaxSlices).ToString();
        sliceIcon.color = ChangeColor();
        cash.text = (heroInfo.GetComponent<HeroInfo>().Money).ToString();
        SetTime();
        SetLife();
    }


    Color ChangeColor()
    {
        float col = 1-(float)heroInfo.GetComponent<HeroInfo>().CurrentSlices / (float)heroInfo.GetComponent<HeroInfo>().MaxSlices;
        if (heroInfo.GetComponent<HeroInfo>().CurrentSlices == 0) currAmmo.color = Color.red;
        if (heroInfo.GetComponent<HeroInfo>().CurrentSlices != 0) currAmmo.color = Color.white;
        return new Color(1, 1-col*0.7f, 0);
    }
    void SetTime()
    {
        time += Time.deltaTime;
        int minutes = (int)time / 60;
        string retTime;
        if (minutes>0)
        {
            if (time - minutes * 60 > 10)
                retTime = minutes + ":" + (int)(time - minutes * 60);
            else
                retTime = minutes + ":0" + (int)(time - minutes * 60);
        }
        else
        {
            if (time > 10)
                retTime = ((int)time).ToString();
            else
                retTime="0"+ ((int)time).ToString();
        }
        retTime += "." + (int)((time - (int)time) * 10);
        timer.text = retTime;
        timerS.text = retTime;
    }
    void SetLife()
    {
        int currLife = heroInfo.GetComponent<HeroInfo>().CurrentHp;
        if (currLife < 5) life5.color = new Color(0, 0, 0, 0);
        if (currLife < 4) life4.color = new Color(0, 0, 0, 0);
        if (currLife < 3) life3.color = new Color(0, 0, 0, 0);
        if (currLife < 2) life2.color = new Color(0, 0, 0, 0);
        if (currLife < 1)
        {
            life1.color = new Color(0, 0, 0, 0);
            SceneManager.LoadScene("Menu");
        }
            
        
    }
}
