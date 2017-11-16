using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeDrug : MonoBehaviour {

    public GameObject levelInfo;
    public GameObject gate;
    public GameObject body;
    public GameObject ball1;
    public GameObject ball2;
    public GameObject ball3;
    public GameObject ball4;
    public GameObject ball5;
    public GameObject ball6;
    public GameObject ball7;
    public GameObject ball8;

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Player")
        {
            levelInfo.GetComponent<LevelInfo>().isFreeze = true;
            gate.gameObject.SetActive(false);
            Freeze();
            Destroy(body);
        }
    }

    void Freeze()
    {
        FreezeObject(ball1);
        FreezeObject(ball2);
        FreezeObject(ball3);
        FreezeObject(ball4);
        FreezeObject(ball5);
        FreezeObject(ball6);
        FreezeObject(ball7);
        FreezeObject(ball8);
    }

    void FreezeObject(GameObject ball)
    {
        ball.GetComponent<FallingBall>().spinSpeed = 50;
        ball.GetComponent<FallingBall>().fallSpeed = 1;
    }
}
