using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliceAmmo : MonoBehaviour {

    public int MaxAmmo;
    public int CurrentAmmo;
    bool isActivated;
    public GameObject slice;
    List<GameObject> sliceList;


	// Use this for initialization
	void Start () {
        sliceList = new List<GameObject>();
        isActivated = false;
        CheckStats();
	}
	
	// Update is called once per frame
	void Update () {

        //Stworz/schowaj plasterek
        if(Input.GetButtonDown("ActiveSlice"))
        {
            if (!isActivated) AddSlice();
            else RemoveSlice();           
        }
    }

    void AddSlice()
    {
        if(CurrentAmmo>0)
        {
            var newSlice = Instantiate(slice, Vector3.zero, Quaternion.identity) as GameObject;
            sliceList.Add(newSlice);
            newSlice.gameObject.SetActive(true);
            newSlice.name = "Slice" ;
            if(Input.GetButton("Backward"))
            {
                newSlice.transform.position = transform.position + new Vector3(-8, 0, 0);
                newSlice.transform.Rotate(Vector3.back, 180);
            }
               
            else if(Input.GetButton("Jump"))
            {
                newSlice.transform.position = transform.position + new Vector3(0, -6, 0);
                if (Input.GetButton("SetSlice"))
                {
                    newSlice.GetComponent<ControlSlice>().SetSlice();
                }
            }               
            else newSlice.transform.position=transform.position+new Vector3(8,0,0);
            newSlice.GetComponent<ControlSlice>().SetCursor("DELETE");
            CurrentAmmo--;
            isActivated = true;
            UpdateStats();
        }
    }

    void RemoveSlice()
    {
        if (sliceList[sliceList.Count - 1].GetComponent<ControlSlice>().isUsing == false) AddSlice();
        else
        {
            sliceList[sliceList.Count - 1].GetComponent<ControlSlice>().SetCursor("DELETE");
            Destroy(sliceList[sliceList.Count - 1]);
            sliceList.RemoveAt(sliceList.Count-1);
            CurrentAmmo++;
            isActivated = false;
            UpdateStats();
        }
    }


    void CheckStats()
    {
        MaxAmmo = GameObject.Find("HeroInfo").GetComponent<HeroInfo>().MaxSlices;
        CurrentAmmo = GameObject.Find("HeroInfo").GetComponent<HeroInfo>().CurrentSlices;
    }

    void UpdateStats()
    {
        GameObject.Find("HeroInfo").GetComponent<HeroInfo>().CurrentSlices = CurrentAmmo;
    }
}
