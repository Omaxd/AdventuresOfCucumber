using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour {

    public GameObject spice;

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Player")
        {
            FallDown();
        }
    }

    void FallDown()
    {
        spice.GetComponent<Rigidbody>().useGravity = true;
        GameObject.Find("SoundInfo").GetComponent<SoundInfo>().fallingTrap.Play();
    }
}
