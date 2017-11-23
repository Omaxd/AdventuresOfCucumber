using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

    Rigidbody button;
    public Rigidbody wallToDestroy;

	// Use this for initialization
	void Start () {
        button = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Player" || other.transform.tag == "Slice")
        {
            wallToDestroy.transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y - 0.2f, transform.localPosition.z);
        }
    }
}
