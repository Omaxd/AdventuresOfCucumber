using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour {

    public GameObject topOfChest;
    public TextMesh message;
    public bool isOpen = false;

	void OnTriggerStay (Collider col) {
	    if (col.gameObject.tag == "Player" && !isOpen)
	    {
            message.text = "Kliknij F by \n otworzyć skrzynię!";
	        if (Input.GetButtonDown("OpenChest"))
	        {
                OpenChest();
	        }
	    }
	}

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            message.text = "";
        }
    }

    void AddMoney(int min, int max)
    {
        GameObject.Find("SoundInfo").GetComponent<SoundInfo>().openChest.Play();
        int addingMoney=Random.Range(min, max);
        GameObject.Find("HeroInfo").GetComponent<HeroInfo>().Money += addingMoney;
        message.text="Znalazłeś " + addingMoney +"\n"+ "monetek!";
    }
    void OpenChest()
    {
        isOpen = true;
        message.text = "";
        AddMoney(5, 30);
        topOfChest.transform.localRotation = Quaternion.Euler(0, 0, -30);
    }
}
