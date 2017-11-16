using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBall : MonoBehaviour {

    public float fallSpeed = 8.0f;
    public float spinSpeed = 250.0f;

    public Vector3 pos;

    void Start()
    {
        pos = transform.position;
    }
    // Update is called once per frame
    void Update () {
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime, Space.World);
        transform.Rotate(Vector3.forward, spinSpeed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Floor")
        {
            transform.position = pos;
        }
        if(other.transform.tag == "Slice")
        {
            other.gameObject.active = false;
        }
    }

}
