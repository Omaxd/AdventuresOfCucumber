using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalGate : MonoBehaviour {

    public GameObject gate;

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Player")
        {
            gate.gameObject.SetActive(true);
        }
    }
}
