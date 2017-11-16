using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestsManager : MonoBehaviour
{

    public GameObject chest1;
    public GameObject chest2;
    public GameObject chest3;
    public GameObject chest4;
    public GameObject chest5;
    public GameObject chest6;
    public GameObject chest7;
    public GameObject chest8;

    public bool ifOpen()
    {
        if (chest1.GetComponent<Chest>().isOpen &&
            chest2.GetComponent<Chest>().isOpen &&
            chest3.GetComponent<Chest>().isOpen &&
            chest4.GetComponent<Chest>().isOpen &&
            chest5.GetComponent<Chest>().isOpen &&
            chest6.GetComponent<Chest>().isOpen &&
            chest7.GetComponent<Chest>().isOpen &&
            chest8.GetComponent<Chest>().isOpen)
            return true;
        else
            return false;
    }
}
