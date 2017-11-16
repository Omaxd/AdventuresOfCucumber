using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
 
    public Vector3 checkpointPosition;

    int moveSpeed;
    int hightOfJump;
    bool canJump;
    int maxLife;
    int currLife;

    public SliceAmmo sliceAmmo;

    void Start() {        
        canJump = true;
        moveSpeed = GameObject.Find("HeroInfo").GetComponent<HeroInfo>().MoveSpeed;
        maxLife = GameObject.Find("HeroInfo").GetComponent<HeroInfo>().MaxHp;
        currLife = maxLife;
        transform.position = new Vector3(-20, 17, -2);
    }

    void Update()
    {
        Move();
        Transform();
        if (transform.position.y < -90) Dead();
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Spikes" || other.transform.tag == "FallingBalls" || other.transform.tag == "Bullet")
        {
            Dead();
        }
    }

    public void Spawn()
    {
        transform.position = checkpointPosition;
    }
    void Dead()
    {
        GameObject.Find("SoundInfo").GetComponent<SoundInfo>().deathSound.Play();
        currLife--;
        GameObject.Find("HeroInfo").GetComponent<HeroInfo>().CurrentHp--;
        Spawn();
    }
    void Transform()
    {
        transform.localScale = new Vector3(transform.localScale.x, sliceAmmo.CurrentAmmo * 0.4f + 4, transform.localScale.z);
        hightOfJump = 20 + (int)((sliceAmmo.MaxAmmo * 2 - sliceAmmo.CurrentAmmo) * 0.5);
    }

    void Move()
    {
        CheckIfCanJump();
        //Do przodu
        if (Input.GetButton("Forward")) { GoForward(); } else GetComponentInChildren<Animator>().SetBool("Idl", true);

        //Do tyłu
        if (Input.GetButton("Backward")) { GoBackward(); } //else GetComponentInChildren<Animator>().SetBool("Idl", true);

        //Skok
        if (Input.GetButtonDown("Jump") && canJump ==true)
        {
            Jump();
        }
        else
        {
            GetComponentInChildren<Animator>().SetBool("Jmp", false);
        }
    }
    void GoForward()
    {
        GetComponent<Transform>().Translate(new Vector3(moveSpeed, 0, 0) * Time.deltaTime);
        if (GetComponentInChildren<Transform>().Find("CucModel").localScale.y < 0)
        {
            GetComponent<Transform>().Find("CucModel").localScale =
                new Vector3(GetComponentInChildren<Transform>().Find("CucModel").localScale.x,
                (GetComponentInChildren<Transform>().Find("CucModel").localScale.y * -1.0f),
                GetComponentInChildren<Transform>().Find("CucModel").localScale.z);
        }
        GetComponentInChildren<Animator>().SetBool("Idl", false);
    }
    void GoBackward()
    {
        GetComponent<Transform>().Translate(new Vector3(-moveSpeed, 0, 0) * Time.deltaTime);
        if (GetComponentInChildren<Transform>().Find("CucModel").localScale.y > 0)
        {
            GetComponent<Transform>().Find("CucModel").localScale =
                new Vector3(GetComponentInChildren<Transform>().Find("CucModel").localScale.x,
                (GetComponentInChildren<Transform>().Find("CucModel").localScale.y * -1.0f),
                GetComponentInChildren<Transform>().Find("CucModel").localScale.z);
        }
        GetComponentInChildren<Animator>().SetBool("Idl", false);
    }
    void CheckIfCanJump()
    {
        if (GetComponent<Rigidbody>().velocity.magnitude == 0 || GetComponent<Rigidbody>().velocity.y == 0) canJump = true;
    }
    void Jump()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, hightOfJump, 0);
        GetComponentInChildren<Animator>().SetBool("Jmp", true);
        canJump = false;
    }

}
