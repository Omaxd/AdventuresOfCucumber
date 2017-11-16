using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialSlices : MonoBehaviour {

    public Dictionary<string, int> listOfSpecialSlices;
    public int indexOfUsingSlice;
    public bool specialSliceModeOn;

    public GameObject teleportSlice;
    public GameObject shieldSlice;

	// Use this for initialization
	void Start () {
        FillListOfSpecialSlices();
        indexOfUsingSlice = 0;
        specialSliceModeOn = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    void FillListOfSpecialSlices()
    {
        listOfSpecialSlices = new Dictionary<string, int>();
        listOfSpecialSlices.Add("TeleportSlices", 1);
        listOfSpecialSlices.Add("ImmortalSlices", 1);
    }

    void ControlSpecialSlices()
    {
        if (Input.GetButtonDown("SpecialSlice"))
        {
            if (specialSliceModeOn == false) specialSliceModeOn = true;
            else specialSliceModeOn = false;
        }

    }

    void SelectSpecialSlice()
    {
        switch(indexOfUsingSlice)
        {
            case 0:
                {

                    break;
                }
        }
    }


}
